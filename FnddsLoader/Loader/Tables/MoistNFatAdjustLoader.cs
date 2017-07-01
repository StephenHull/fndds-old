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
    /// This class contains functionaility for loading data for the moisture and fat
    /// weight adjustment table.
    /// </summary>
    public class MoistNFatAdjustLoader : DataLoader
    {
        /// <summary>
        /// The table name in the source database.
        /// </summary>
        private const string SourceTableName = "MoistNFatAdjust";

        /// <summary>
        /// The logger class.
        /// </summary>
        private readonly ILog _logger = LogManager.GetLogger(typeof(MoistNFatAdjustLoader));

        /// <summary>
        /// True if the logger is debug endabled; otherwise, false.
        /// </summary>
        private bool _isDebugEnabled = false;

        /// <summary>
        /// Constructs a new MoistNFatAdjustLoader object.
        /// </summary>
        /// <param name="version">The FNDDS version.</param>
        /// <param name="connection">The connection to the source database.</param>
        /// <param name="context">The destination database context.</param>
        public MoistNFatAdjustLoader(FnddsVersion version, OleDbConnection connection, FnddsContext context)
            : base(version, connection, context)
        {
            _isDebugEnabled = _logger.IsDebugEnabled;
        }

        /// <inheritdoc />
        public override async Task<int> CreateRecordsAsync(IEnumerable<DataColumn> columns, OleDbDataReader reader)
        {
            var adjusts = new List<MoistNFatAdjust>();

            var recordCount = 0;
            while (reader.Read())
            {
                var adjust = new MoistNFatAdjust
                {
                    Version = FnddsVersion.Id,
                    Created = DateTime.Now
                };

                SetModelValues(columns, reader, adjust);

                adjusts.Add(adjust);

                if (_isDebugEnabled)
                {
                    _logger.DebugFormat("Table: {0}, Food code: {1}", SourceTableName, adjust.FoodCode);
                }

                if (adjusts.Count > BatchSize)
                {
                    Context.MoistNFatAdjust.AddRange(adjusts);

                    await Context.SaveChangesAsync();

                    adjusts.Clear();
                }

                recordCount++;
            }

            if (adjusts.Count > 0)
            {
                Context.MoistNFatAdjust.AddRange(adjusts);

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
                        SourceName = "[Food code]",
                        DestinationName = "FoodCode",
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
                        SourceName = "[Moisture change]",
                        DestinationName = "MoistureChange",
                        Versions = new HashSet<int> { 1, 2, 4, 8, 16, 32, 64 }
                    },
                    new DataColumn
                    {
                        SourceName = "[Fat change]",
                        DestinationName = "FatChange",
                        Versions = new HashSet<int> { 1, 2, 4, 8, 16, 32, 64 }
                    },
                    new DataColumn
                    {
                        SourceName = "[Type of fat]",
                        DestinationName = "TypeOfFat",
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