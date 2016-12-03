using FnddsLoader.Model;
using log4net;
using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Threading.Tasks;

namespace FnddsLoader.Loader.Tables
{
    /// <summary>
    /// This class contains functionaility for loading data for the main food
    /// description table.
    /// </summary>
    public class MainFoodDescLoader : DataLoader
    {
        /// <summary>
        /// The table name in the source database.
        /// </summary>
        private const string SourceTableName = "MainFoodDesc";

        /// <summary>
        /// The logger class.
        /// </summary>
        private ILog _logger = LogManager.GetLogger(typeof(MainFoodDescLoader));

        /// <summary>
        /// True if the logger is debug endabled; otherwise, false.
        /// </summary>
        private bool _isDebugEnabled = false;

        /// <summary>
        /// Constructs a new MainFoodDescLoader object.
        /// </summary>
        /// <param name="version">The FNDDS version.</param>
        /// <param name="connection">The connection to the source database.</param>
        /// <param name="context">The destination database context.</param>
        public MainFoodDescLoader(FnddsVersion version, OleDbConnection connection, FnddsContext context)
            : base(version, connection, context)
        {
            _isDebugEnabled = _logger.IsDebugEnabled;
        }

        /// <inheritdoc />
        public override async Task<int> CreateRecordsAsync(IEnumerable<DataColumn> columns, OleDbDataReader reader)
        {
            var foods = new List<MainFoodDesc>();

            var recordCount = 0;
            while (reader.Read())
            {
                var food = new MainFoodDesc
                {
                    Version = FnddsVersion.Id,
                    Created = DateTime.Now
                };

                SetModelValues(columns, reader, food);

                foods.Add(food);

                if (_isDebugEnabled)
                {
                    _logger.DebugFormat("Table: {0}, Food code: {1}", SourceTableName, food.FoodCode);
                }

                if (foods.Count > BatchSize)
                {
                    Context.MainFoodDesc.AddRange(foods);

                    await Context.SaveChangesAsync();

                    foods.Clear();
                }

                recordCount++;
            }

            if (foods.Count > 0)
            {
                Context.MainFoodDesc.AddRange(foods);

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
                        SourceName = "[Main food description]",
                        DestinationName = "MainFoodDescription",
                        Versions = new HashSet<int> { 1, 2, 4, 8, 16, 32, 64 }
                    },
                    new DataColumn
                    {
                        SourceName = "[Abbreviated description]",
                        DestinationName = "AbbreviatedMainFoodDescription",
                        Versions = new HashSet<int> { 1, 2, 4 }
                    },
                    new DataColumn
                    {
                        SourceName = "[Fortification identifier]",
                        DestinationName = "FortificationIdentifier",
                        Versions = new HashSet<int> { 32 }
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