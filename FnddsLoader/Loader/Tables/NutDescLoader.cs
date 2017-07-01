namespace FnddsLoader.Loader.Tables
{
    using Base.Loader;
    using log4net;
    using Model;
    using System;
    using System.Collections.Generic;
    using System.Data.OleDb;
    using System.Threading.Tasks;

    /// <summary>
    /// This class contains functionaility for loading data for the nutrient
    /// description table.
    /// </summary>
    public class NutDescLoader : DataLoader
    {
        /// <summary>
        /// The table name in the source database.
        /// </summary>
        private const string SourceTableName = "NutDesc";

        /// <summary>
        /// The logger class.
        /// </summary>
        private readonly ILog _logger = LogManager.GetLogger(typeof(NutDescLoader));

        /// <summary>
        /// True if the logger is debug endabled; otherwise, false.
        /// </summary>
        private bool _isDebugEnabled = false;

        /// <summary>
        /// Constructs a new NutDescLoader object.
        /// </summary>
        /// <param name="version">The FNDDS version.</param>
        /// <param name="connection">The connection to the source database.</param>
        /// <param name="context">The destination database context.</param>
        public NutDescLoader(FnddsVersion version, OleDbConnection connection, FnddsContext context)
            : base(version, connection, context)
        {
            _isDebugEnabled = _logger.IsDebugEnabled;
        }

        /// <inheritdoc />
        public override async Task<int> CreateRecordsAsync(IEnumerable<DataColumn> columns, OleDbDataReader reader)
        {
            var nutrients = new List<NutDesc>();

            var recordCount = 0;
            while (reader.Read())
            {
                var nutrient = new NutDesc
                {
                    Version = FnddsVersion.Id,
                    Created = DateTime.Now
                };

                SetModelValues(columns, reader, nutrient);

                nutrients.Add(nutrient);

                if (_isDebugEnabled)
                {
                    _logger.DebugFormat("Table: {0}, Nutrient code: {1}", SourceTableName, nutrient.NutrientCode);
                }

                if (nutrients.Count > BatchSize)
                {
                    Context.NutDesc.AddRange(nutrients);

                    await Context.SaveChangesAsync();

                    nutrients.Clear();
                }

                recordCount++;
            }

            Context.NutDesc.AddRange(nutrients);

            await Context.SaveChangesAsync();

            return recordCount;
        }

        /// <inheritdoc />
        public override IEnumerable<DataColumn> Columns
        {
            get
            {
                var columns = new List<DataColumn>
                {
                    new DataColumn
                    {
                        SourceName = "[Nutrient code]",
                        DestinationName = "NutrientCode",
                        IsOrderBy = true,
                        Versions = new HashSet<int> { 1, 2, 4, 8, 16, 32, 64 }
                    },
                    new DataColumn
                    {
                        SourceName = "[Nutrient description]",
                        DestinationName = "NutrientDescription",
                        Versions = new HashSet<int> { 1, 2, 4, 8, 16, 32, 64 }
                    },
                    new DataColumn
                    {
                        SourceName = "Tagname",
                        DestinationName = "Tagname",
                        Versions = new HashSet<int> { 1, 2, 4, 8, 16, 32, 64 }
                    },
                    new DataColumn
                    {
                        SourceName = "Unit",
                        DestinationName = "Unit",
                        Versions = new HashSet<int> { 1, 2, 4, 8, 16, 32, 64 }
                    },
                    new DataColumn
                    {
                        SourceName = "Decimals",
                        DestinationName = "Decimals",
                        Versions = new HashSet<int> { 1, 2, 4, 8, 16, 32, 64 }
                    }
                };

                return columns;
            }
        }

        /// <inheritdoc />
        public override string TableName
        {
            get
            {
                return SourceTableName;
            }
        }
    }
}