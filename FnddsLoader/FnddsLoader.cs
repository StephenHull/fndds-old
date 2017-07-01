namespace FnddsLoader
{
    using Loader;
    using Loader.Tables;
    using log4net;
    using log4net.Config;
    using Model;
    using System;
    using System.Collections.Generic;
    using System.Configuration;
    using System.Data.OleDb;
    using System.Linq;
    using System.Threading.Tasks;
    using Utility;

    /// <summary>
    /// This class is a utility for loading FNDDS data from USDA into a database.
    /// </summary>
    public class FnddsLoader
    {
        /// <summary>
        /// The logger class.
        /// </summary>
        private static readonly ILog _logger = LogManager.GetLogger(typeof(FnddsLoader));

        /// <summary>
        /// True if the logger is debug endabled; otherwise, false.
        /// </summary>
        private bool _isDebugEnabled = false;

        /// <summary>
        /// Gets or sets the connection string for the destination database.
        /// </summary>
        public string ConnectionString { get; set; }

        /// <summary>
        /// Constructs a new FNDDS loader.
        /// </summary>
        public FnddsLoader()
        {
            // Configure the logger
            XmlConfigurator.Configure();

            _isDebugEnabled = _logger.IsDebugEnabled;

            // Get the connection string
            var settings = ConfigurationManager.ConnectionStrings["Fndds"];
            if (settings != null)
            {
                ConnectionString = settings.ConnectionString;
            }
        }

        /// <summary>
        /// Imports data from a source database.
        /// </summary>
        /// <param name="fnddsVersion">The FNDDS version.</param>
        /// <param name="connString">The connection string for the source database.</param>
        /// <param name="modConnString">The connection string for the source modification database.</param>
        /// <param name="equivConnString">The connection string for the source equivalents database.</param>
        /// <returns>Returns true if the method completes successfully.</returns>
        public async Task<bool> ImportDataAsync(FnddsVersion fnddsVersion, string connString, string modConnString = null, string equivConnString = null)
        {
            using (var context = new FnddsContext())
            {
                var version = context.FnddsVersion.SingleOrDefault(x => x.Id == fnddsVersion.Id);
                if (version != null)
                {
                    context.FnddsVersion.Remove(version);

                    await context.SaveChangesAsync();
                }

                version = new FnddsVersion
                {
                    Id = fnddsVersion.Id,
                    BeginYear = fnddsVersion.BeginYear,
                    EndYear = fnddsVersion.EndYear,
                    Major = fnddsVersion.Major,
                    Minor = fnddsVersion.Minor,
                    Created = DateTime.Now
                };

                context.FnddsVersion.Add(version);

                await context.SaveChangesAsync();

                using (var connection = new OleDbConnection(connString))
                {
                    await connection.OpenAsync();

                    var loaders = new List<DataLoader>
                    {
                        new FoodPortionDescLoader(version, connection, context),
                        new SubcodeDescLoader(version, connection, context),
                        new MainFoodDescLoader(version, connection, context),
                        new NutDescLoader(version, connection, context),
                        new FoodWeightsLoader(version, connection, context),
                        new MoistNFatAdjustLoader(version, connection, context),
                        new AddFoodDescLoader(version, connection, context),
                        new FNDDSSRLinksLoader(version, connection, context),
                        new FNDDSNutValLoader(version, connection, context)
                    };

                    foreach (var loader in loaders)
                    {
                        var recordsLoaded = await loader.LoadAsync();

                        if (_isDebugEnabled)
                        {
                            _logger.DebugFormat("Table: {0}, Records: {1}", loader.TableName, recordsLoaded);
                        }
                    }
                }

                var canLoadMods = (version.Id > 1 && version.Id < 64);
                if (version.Id < 16 && string.IsNullOrEmpty(modConnString) == false)
                {
                    canLoadMods = true;
                    connString = modConnString;
                    ModNutValLoader.SourceTableName = "ModNut";
                }

                if (canLoadMods)
                {
                    using (var connection = new OleDbConnection(connString))
                    {
                        await connection.OpenAsync();

                        var loaders = new List<DataLoader>
                        {
                            new ModDescLoader(version, connection, context),
                            new ModNutValLoader(version, connection, context)
                        };

                        if (version.Id < 16)
                        {
                            loaders.Add(new NoSaltModNutValLoader(version, connection, context));
                        }

                        foreach (var loader in loaders)
                        {
                            var recordsLoaded = await loader.LoadAsync();

                            if (_isDebugEnabled)
                            {
                                _logger.DebugFormat("Table: {0}, Records: {1}", loader.TableName, recordsLoaded);
                            }
                        }
                    }
                }
            }

            return true;
        }

        /// <summary>
        /// The main method. This method simply calls MainAsync.
        /// </summary>
        /// <param name="args">The command-line arguments.</param>
        /// <remarks>
        /// Arguments:
        ///     fnddsVersion {Integer} the FNDDS version
        ///         1   = FNDDS 1.0 (2001-2002)
        ///         2   = FNDDS 2.0 (2003-2004)
        ///         4   = FNDDS 3.0 (2005-2006)
        ///         8   = FNDDS 4.1 (2007-2008)
        ///         16  = FNDDS 5.0 (2009-2010)
        ///         32  = FNDDS 2011-2012
        ///         64  = FNDDS 2013-2014
        ///         128 = FNDDS 2015-2016
        ///     connString {String} the FNDDS Access database OLEDB connection string
        ///         Example: Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\databases\FNDDS.mdb;Persist Security Info=False;"
        ///     modConnString {String} the FNDDS Modifications Access database OLEDB connection string
        /// </remarks>
        static void Main(string[] args)
        {
            MainAsync(args).GetAwaiter().GetResult();
        }

        /// <summary>
        /// The async main method. This method is where the work is done.
        /// </summary>
        /// <param name="args">The command-line arguments.</param>
        public static async Task MainAsync(string[] args)
        {
            if (args.Length < 2)
            {
                _logger.Fatal("Missing connand-line arguments.");

                Environment.Exit(0);
            }

            _logger.DebugFormat("FNDDS Version ID: {0}", args[0]);
            _logger.DebugFormat("Local Connection String: {0}", args[1]);
            if (args.Length == 3)
            {
                _logger.DebugFormat("Local Mod Connection String: {0}", args[2]);
            }

            var loader = new FnddsLoader();

            var id = -1;
            var connString = string.Empty;
            var modConnString = string.Empty;
            var equivConnString = string.Empty;

            try
            {
                id = Convert.ToInt32(args[0]);
                connString = args[1].ToString();
                if (args.Length > 2)
                {
                    modConnString = args[2].ToString();
                }

                if (args.Length > 3)
                {
                    equivConnString = args[3].ToString();
                }
            }
            catch (Exception e)
            {
                _logger.Fatal("An error occurred parsing the connand-line arguments.", e);
            }

            var version = VersionUtility.GetVersionFromId(id);
            if (version == null)
            {
                _logger.Fatal("Invalid FNDDS version.");

                Environment.Exit(0);
            }

            await loader.ImportDataAsync(version, connString, modConnString, equivConnString);
        }
    }
}