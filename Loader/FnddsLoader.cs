using FnddsLoader.Loader;
using FnddsLoader.Loader.Tables;
using FnddsLoader.Model;
using FnddsLoader.Utility;
using log4net;
using log4net.Config;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.OleDb;
using System.Linq;
using System.Threading.Tasks;

namespace FnddsLoader
{
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
        /// <returns></returns>
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

                var canEquivalents = (version.Id > 2 && version.Id < 64);
                if (canEquivalents)
                {
                    if (version.Id == 4)
                    {
                        EquivalentLoader.SourceTableName = "FPED_0506";
                        ModEquivalentLoader.SourceTableName = "FPED_0506";
                    }
                    else if (version.Id == 8)
                    {
                        EquivalentLoader.SourceTableName = "FPED_0708";
                        ModEquivalentLoader.SourceTableName = "FPED_0708";
                    }
                    else if (version.Id == 16)
                    {
                        EquivalentLoader.SourceTableName = "FPED_0910";
                        ModEquivalentLoader.SourceTableName = "FPED_0910";
                    }
                    else if (version.Id == 32)
                    {
                        EquivalentLoader.SourceTableName = "FPED_1112";
                        ModEquivalentLoader.SourceTableName = "FPED_1112";
                    }

                    using (var connection = new OleDbConnection(equivConnString))
                    {
                        await connection.OpenAsync();

                        var loaders = new List<DataLoader>
                        {
                            new EquivalentLoader(version, connection, context),
                            new ModEquivalentLoader(version, connection, context)
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
                }
            }

            return true;
        }

        /// <summary>
        /// The main method. This method simply calls MainAsync.
        /// </summary>
        /// <param name="args">The command-line arguments.</param>
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

            _logger.DebugFormat("ID: {0}", args[0]);
            _logger.DebugFormat("Local Connection String: {0}", args[1]);
            if (args.Length == 3)
            {
                _logger.DebugFormat("Local Mod Connection String: {0}", args[2]);
            }

            var loader = new FnddsLoader();

            var id = -1;
            var connString = string.Empty;
            var modConnString = string.Empty;

            try
            {
                id = Convert.ToInt32(args[0]);
                connString = args[1].ToString();
                if (args.Length == 3)
                {
                    modConnString = args[2].ToString();
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

            await loader.ImportDataAsync(version, connString, modConnString);
        }

        public async Task<bool> RemoveDataAsync()
        {
            using (var context = new FnddsContext())
            {
                context.FnddsVersion.RemoveRange(context.FnddsVersion);

                await context.SaveChangesAsync();
            }

            return true;
        }
    }
}