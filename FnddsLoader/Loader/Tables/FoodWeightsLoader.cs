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
    /// This class contains functionaility for loading data for the food weights table.
    /// </summary>
    public class FoodWeightsLoader : DataLoader
    {
        /// <summary>
        /// The table name in the source database.
        /// </summary>
        private const string SourceTableName = "FoodWeights";

        /// <summary>
        /// The logger class.
        /// </summary>
        private readonly ILog _logger = LogManager.GetLogger(typeof(FoodWeightsLoader));

        /// <summary>
        /// True if the logger is debug endabled; otherwise, false.
        /// </summary>
        private bool _isDebugEnabled = false;

        /// <summary>
        /// Constructs a new FoodWeightsLoader object.
        /// </summary>
        /// <param name="version">The FNDDS version.</param>
        /// <param name="connection">The connection to the source database.</param>
        /// <param name="context">The destination database context.</param>
        public FoodWeightsLoader(FnddsVersion version, OleDbConnection connection, FnddsContext context)
            : base(version, connection, context)
        {
            _isDebugEnabled = _logger.IsDebugEnabled;
        }

        /// <inheritdoc />
        public override async Task<int> CreateRecordsAsync(IEnumerable<DataColumn> columns, OleDbDataReader reader)
        {
            var weights = new List<FoodWeights>();

            var recordCount = 0;
            while (reader.Read())
            {
                var weight = new FoodWeights
                {
                    Version = FnddsVersion.Id,
                    Created = DateTime.Now
                };

                SetModelValues(columns, reader, weight);

                weights.Add(weight);

                if (_isDebugEnabled)
                {
                    _logger.DebugFormat("Table: {0}, Food code: {1}, Subcode: {2}, Sequence: {3}, Portion code: {4}", SourceTableName, weight.FoodCode, weight.Subcode, weight.SeqNum, weight.PortionCode);
                }

                if (weights.Count > BatchSize)
                {
                    Context.FoodWeights.AddRange(weights);

                    await Context.SaveChangesAsync();

                    weights.Clear();
                }

                recordCount++;
            }

            if (weights.Count > 0)
            {
                Context.FoodWeights.AddRange(weights);

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
                        SourceName = "[Subcode]",
                        DestinationName = "Subcode",
                        IsOrderBy = true,
                        Versions = new HashSet<int> { 1, 2, 4, 8, 16, 32, 64 }
                    },
                    new DataColumn
                    {
                        SourceName = "[Seq num]",
                        DestinationName = "SeqNum",
                        IsOrderBy = true,
                        Versions = new HashSet<int> { 1, 2, 4, 8, 16, 32, 64 }
                    },
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
                        SourceName = "[Portion weight]",
                        DestinationName = "PortionWeight",
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