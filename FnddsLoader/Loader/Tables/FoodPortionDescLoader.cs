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
    /// This class contains functionaility for loading data for the food portion
    /// description table.
    /// </summary>
    public class FoodPortionDescLoader : DataLoader
    {
        /// <summary>
        /// The table name in the source database.
        /// </summary>
        private const string SourceTableName = "FoodPortionDesc";

        /// <summary>
        /// The logger class.
        /// </summary>
        private readonly ILog _logger = LogManager.GetLogger(typeof(FoodPortionDescLoader));

        /// <summary>
        /// True if the logger is debug endabled; otherwise, false.
        /// </summary>
        private bool _isDebugEnabled = false;

        /// <summary>
        /// Constructs a new FoodPortionDescLoader object.
        /// </summary>
        /// <param name="version">The FNDDS version.</param>
        /// <param name="connection">The connection to the source database.</param>
        /// <param name="context">The destination database context.</param>
        public FoodPortionDescLoader(FnddsVersion version, OleDbConnection connection, FnddsContext context)
            : base(version, connection, context)
        {
            _isDebugEnabled = _logger.IsDebugEnabled;
        }

        /// <inheritdoc />
        public override async Task<int> CreateRecordsAsync(IEnumerable<DataColumn> columns, OleDbDataReader reader)
        {
            var portions = new List<FoodPortionDesc>();

            var recordCount = 0;
            while (reader.Read())
            {
                var portion = new FoodPortionDesc
                {
                    Version = FnddsVersion.Id,
                    Created = DateTime.Now
                };

                SetModelValues(columns, reader, portion);

                portions.Add(portion);

                if (_isDebugEnabled)
                {
                    _logger.DebugFormat("Table: {0}, Portion code: {1}", SourceTableName, portion.PortionCode);
                }

                if (portions.Count > BatchSize)
                {
                    Context.FoodPortionDesc.AddRange(portions);

                    await Context.SaveChangesAsync();

                    portions.Clear();
                }

                recordCount++;
            }

            if (portions.Count > 0)
            {
                Context.FoodPortionDesc.AddRange(portions);

                await Context.SaveChangesAsync();
            }

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
                        SourceName = "[Portion code]",
                        DestinationName = "PortionCode",
                        IsOrderBy = true,
                        Versions = new HashSet<int> { 1, 2, 4, 8, 16, 32, 64 }
                    },
                    new DataColumn
                    {
                        SourceName = "[Start date]",
                        DestinationName = "StartDate",
                        Versions = new HashSet<int> { 1, 2, 4, 8, 16, 32, 64 }
                    },
                    new DataColumn
                    {
                        SourceName = "[End date]",
                        DestinationName = "EndDate",
                        Versions = new HashSet<int> { 1, 2, 4, 8, 16, 32, 64 }
                    },
                    new DataColumn
                    {
                        SourceName = "[Portion description]",
                        DestinationName = "PortionDescription",
                        Versions = new HashSet<int> { 1, 2, 4, 8, 16, 32, 64 }
                    },
                    new DataColumn
                    {
                        SourceName = "[Change type]",
                        DestinationName = "ChangeType",
                        Versions = new HashSet<int> { 1, 2, 4, 8, 16, 32 }
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