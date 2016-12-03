using FnddsLoader.Model;
using log4net;
using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Threading.Tasks;

namespace FnddsLoader.Loader.Tables
{
    /// <summary>
    /// This class contains functionaility for loading data for the food modification
    /// nutrient values table.
    /// </summary>
    public class ModNutValLoader : DataLoader
    {
        /// <summary>
        /// The table name in the source database.
        /// </summary>
        private const string SourceTableName = "ModNutVal";

        /// <summary>
        /// The logger class.
        /// </summary>
        private readonly ILog _logger = LogManager.GetLogger(typeof(ModNutValLoader));

        /// <summary>
        /// True if the logger is debug endabled; otherwise, false.
        /// </summary>
        private bool _isDebugEnabled = false;

        /// <summary>
        /// Constructs a new ModNutValLoader object.
        /// </summary>
        /// <param name="version">The FNDDS version.</param>
        /// <param name="connection">The connection to the source database.</param>
        /// <param name="context">The destination database context.</param>
        public ModNutValLoader(FnddsVersion version, OleDbConnection connection, FnddsContext context)
            : base(version, connection, context)
        {
            _isDebugEnabled = _logger.IsDebugEnabled;
        }

        /// <inheritdoc />
        public override async Task<int> CreateRecordsAsync(IEnumerable<DataColumn> columns, OleDbDataReader reader)
        {
            var nutrients = new List<ModNutVal>();

            var recordCount = 0;
            while (reader.Read())
            {
                var nutrient = new ModNutVal
                {
                    Version = FnddsVersion.Id,
                    Created = DateTime.Now
                };

                SetModelValues(columns, reader, nutrient);

                var foodCode = Context.ModDesc.Where(x => x.ModificationCode == nutrient.ModificationCode).Select(x => x.FoodCode).Single();

                nutrient.FoodCode = foodCode;

                nutrients.Add(nutrient);

                if (_isDebugEnabled)
                {
                    _logger.DebugFormat("Table: {0}, Food code: {1}, Modification code: {2}, Nutrient code: {3}", SourceTableName, nutrient.FoodCode, nutrient.ModificationCode, nutrient.NutrientCode);
                }

                if (nutrients.Count > BatchSize)
                {
                    Context.ModNutVal.AddRange(nutrients);

                    await Context.SaveChangesAsync();

                    nutrients.Clear();
                }

                recordCount++;
            }

            if (nutrients.Count > 0)
            {
                Context.ModNutVal.AddRange(nutrients);

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
                        SourceName = "[Modification code]",
                        DestinationName = "ModificationCode",
                        IsOrderBy = true,
                        Versions = new HashSet<int> { 16, 32 }
                    },
                    new DataColumn
                    {
                        SourceName = "[Nutrient code]",
                        DestinationName = "NutrientCode",
                        IsOrderBy = true,
                        Versions = new HashSet<int> { 16, 32 }
                    },
                    new DataColumn
                    {
                        SourceName = "[Start date]",
                        DestinationName = "StartDate",
                        Versions = new HashSet<int> { 16, 32 }
                    },
                    new DataColumn
                    {
                        SourceName = "[End date]",
                        DestinationName = "EndDate",
                        Versions = new HashSet<int> { 16, 32 }
                    },
                    new DataColumn
                    {
                        SourceName = "[Nutrient value]",
                        DestinationName = "NutrientValue",
                        Versions = new HashSet<int> { 16, 32 }
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