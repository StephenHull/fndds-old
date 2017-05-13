using FnddsLoader.Model;
using log4net;
using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Threading.Tasks;

namespace FnddsLoader.Loader.Tables
{
    /// <summary>
    /// This class contains functionaility for loading data for the modification
    /// equivalents table.
    /// </summary>
    public class ModEquivalentLoader : DataLoader
    {
        /// <summary>
        /// The table name in the source database.
        /// </summary>
        public static string SourceTableName = "";

        /// <summary>
        /// The logger class.
        /// </summary>
        private readonly ILog _logger = LogManager.GetLogger(typeof(EquivalentLoader));

        /// <summary>
        /// True if the logger is debug endabled; otherwise, false.
        /// </summary>
        private bool _isDebugEnabled = false;

        /// <summary>
        /// Constructs a new ModEquivalentLoader object.
        /// </summary>
        /// <param name="version">The FNDDS version.</param>
        /// <param name="connection">The connection to the source database.</param>
        /// <param name="context">The destination database context.</param>
        public ModEquivalentLoader(FnddsVersion version, OleDbConnection connection, FnddsContext context)
            : base(version, connection, context)
        {
            _isDebugEnabled = _logger.IsDebugEnabled;
        }

        /// <inheritdoc />
        public override async Task<int> CreateRecordsAsync(IEnumerable<DataColumn> columns, OleDbDataReader reader)
        {
            var equivalents = new List<ModEquivalent>();

            var recordCount = 0;
            while (reader.Read())
            {
                int modCode = reader.GetInt32(1);
                if (modCode == 0)
                {
                    continue;
                }

                var equivalent = new ModEquivalent
                {
                    Version = FnddsVersion.Id,
                    Created = DateTime.Now
                };

                SetModelValues(columns, reader, equivalent);

                equivalents.Add(equivalent);

                if (_isDebugEnabled)
                {
                    _logger.DebugFormat("Table: {0}, Food code: {1}, ModCode: {2}", SourceTableName, equivalent.FoodCode, equivalent.ModCode);
                }

                if (equivalents.Count > BatchSize)
                {
                    Context.ModEquivalent.AddRange(equivalents);

                    await Context.SaveChangesAsync();

                    equivalents.Clear();
                }

                recordCount++;
            }

            if (equivalents.Count > 0)
            {
                Context.ModEquivalent.AddRange(equivalents);

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
                        SourceName = "[Seq num]",
                        DestinationName = "SeqNum",
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
                        SourceName = "[Additional food description]",
                        DestinationName = "AdditionalFoodDescription",
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