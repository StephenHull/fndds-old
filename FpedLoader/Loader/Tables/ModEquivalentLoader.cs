namespace FpedLoader.Loader.Tables
{
    using Base.Loader;
    using log4net;
    using Model;
    using System;
    using System.Collections.Generic;
    using System.Data.OleDb;
    using System.Threading.Tasks;

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
        public ModEquivalentLoader(FnddsVersion version, OleDbConnection connection, FpedContext context)
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
                if (FnddsVersion.Id < 64)
                {
                    int modCode;
                    object value = reader.GetValue(1);
                    if (int.TryParse(value.ToString(), out modCode) == false)
                    {
                        var message = string.Format("Unable to parse mod code value {0}.", value);
                        throw new Exception(message);
                    }

                    if (modCode == 0)
                    {
                        continue;
                    }
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
                        SourceName = "FOODCODE",
                        DestinationName = "FoodCode",
                        IsOrderBy = true,
                        Versions = new HashSet<int> { 4, 8, 16, 32, 64 }
                    },
                    new DataColumn
                    {
                        SourceName = "MODCODE",
                        DestinationName = "ModCode",
                        IsOrderBy = true,
                        Versions = new HashSet<int> { 4, 8, 16, 32 }
                    },
                    new DataColumn
                    {
                        SourceName = "F_CITMLB",
                        DestinationName = "F_CITMLB",
                        Versions = new HashSet<int> { 4, 8, 16, 32, 64 }
                    },
                    new DataColumn
                    {
                        SourceName = "F_OTHER",
                        DestinationName = "F_OTHER",
                        Versions = new HashSet<int> { 4, 8, 16, 32, 64 }
                    },
                    new DataColumn
                    {
                        SourceName = "F_JUICE",
                        DestinationName = "F_JUICE",
                        Versions = new HashSet<int> { 4, 8, 16, 32, 64 }
                    },
                    new DataColumn
                    {
                        SourceName = "F_TOTAL",
                        DestinationName = "F_TOTAL",
                        Versions = new HashSet<int> { 4, 8, 16, 32, 64 }
                    },
                    new DataColumn
                    {
                        SourceName = "V_DRKGR",
                        DestinationName = "V_DRKGR",
                        Versions = new HashSet<int> { 4, 8, 16, 32, 64 }
                    },
                    new DataColumn
                    {
                        SourceName = "V_REDOR_TOMATO",
                        DestinationName = "V_REDOR_TOMATO",
                        Versions = new HashSet<int> { 4, 8, 16, 32, 64 }
                    },
                    new DataColumn
                    {
                        SourceName = "V_REDOR_OTHER",
                        DestinationName = "V_REDOR_OTHER",
                        Versions = new HashSet<int> { 4, 8, 16, 32, 64 }
                    },
                    new DataColumn
                    {
                        SourceName = "V_REDOR_TOTAL",
                        DestinationName = "V_REDOR_TOTAL",
                        Versions = new HashSet<int> { 4, 8, 16, 32, 64 }
                    },
                    new DataColumn
                    {
                        SourceName = "V_STARCHY_POTATO",
                        DestinationName = "V_STARCHY_POTATO",
                        Versions = new HashSet<int> { 4, 8, 16, 32, 64 }
                    },
                    new DataColumn
                    {
                        SourceName = "V_STARCHY_OTHER",
                        DestinationName = "V_STARCHY_OTHER",
                        Versions = new HashSet<int> { 4, 8, 16, 32, 64 }
                    },
                    new DataColumn
                    {
                        SourceName = "V_STARCHY_TOTAL",
                        DestinationName = "V_STARCHY_TOTAL",
                        Versions = new HashSet<int> { 4, 8, 16, 32, 64 }
                    },
                    new DataColumn
                    {
                        SourceName = "V_OTHER",
                        DestinationName = "V_OTHER",
                        Versions = new HashSet<int> { 4, 8, 16, 32, 64 }
                    },
                    new DataColumn
                    {
                        SourceName = "V_TOTAL",
                        DestinationName = "V_TOTAL",
                        Versions = new HashSet<int> { 4, 8, 16, 32, 64 }
                    },
                    new DataColumn
                    {
                        SourceName = "V_LEGUMES",
                        DestinationName = "V_LEGUMES",
                        Versions = new HashSet<int> { 4, 8, 16, 32, 64 }
                    },
                    new DataColumn
                    {
                        SourceName = "G_WHOLE",
                        DestinationName = "G_WHOLE",
                        Versions = new HashSet<int> { 4, 8, 16, 32, 64 }
                    },
                    new DataColumn
                    {
                        SourceName = "G_REFINED",
                        DestinationName = "G_REFINED",
                        Versions = new HashSet<int> { 4, 8, 16, 32, 64 }
                    },
                    new DataColumn
                    {
                        SourceName = "G_TOTAL",
                        DestinationName = "G_TOTAL",
                        Versions = new HashSet<int> { 4, 8, 16, 32, 64 }
                    },
                    new DataColumn
                    {
                        SourceName = "PF_MEAT",
                        DestinationName = "PF_MEAT",
                        Versions = new HashSet<int> { 4, 8, 16, 32, 64 }
                    },
                    new DataColumn
                    {
                        SourceName = "PF_CUREDMEAT",
                        DestinationName = "PF_CUREDMEAT",
                        Versions = new HashSet<int> { 4, 8, 16, 32, 64 }
                    },
                    new DataColumn
                    {
                        SourceName = "PF_ORGAN",
                        DestinationName = "PF_ORGAN",
                        Versions = new HashSet<int> { 4, 8, 16, 32, 64 }
                    },
                    new DataColumn
                    {
                        SourceName = "PF_POULT",
                        DestinationName = "PF_POULT",
                        Versions = new HashSet<int> { 4, 8, 16, 32, 64 }
                    },
                    new DataColumn
                    {
                        SourceName = "PF_SEAFD_HI",
                        DestinationName = "PF_SEAFD_HI",
                        Versions = new HashSet<int> { 4, 8, 16, 32, 64 }
                    },
                    new DataColumn
                    {
                        SourceName = "PF_SEAFD_LOW",
                        DestinationName = "PF_SEAFD_LOW",
                        Versions = new HashSet<int> { 4, 8, 16, 32, 64 }
                    },
                    new DataColumn
                    {
                        SourceName = "PF_MPS_TOTAL",
                        DestinationName = "PF_MPS_TOTAL",
                        Versions = new HashSet<int> { 4, 8, 16, 32, 64 }
                    },
                    new DataColumn
                    {
                        SourceName = "PF_EGGS",
                        DestinationName = "PF_EGGS",
                        Versions = new HashSet<int> { 4, 8, 16, 32, 64 }
                    },
                    new DataColumn
                    {
                        SourceName = "PF_SOY",
                        DestinationName = "PF_SOY",
                        Versions = new HashSet<int> { 4, 8, 16, 32, 64 }
                    },
                    new DataColumn
                    {
                        SourceName = "PF_NUTSDS",
                        DestinationName = "PF_NUTSDS",
                        Versions = new HashSet<int> { 4, 8, 16, 32, 64 }
                    },
                    new DataColumn
                    {
                        SourceName = "PF_LEGUMES",
                        DestinationName = "PF_LEGUMES",
                        Versions = new HashSet<int> { 4, 8, 16, 32, 64 }
                    },
                    new DataColumn
                    {
                        SourceName = "PF_TOTAL",
                        DestinationName = "PF_TOTAL",
                        Versions = new HashSet<int> { 4, 8, 16, 32, 64 }
                    },
                    new DataColumn
                    {
                        SourceName = "D_MILK",
                        DestinationName = "D_MILK",
                        Versions = new HashSet<int> { 4, 8, 16, 32, 64 }
                    },
                    new DataColumn
                    {
                        SourceName = "D_YOGURT",
                        DestinationName = "D_YOGURT",
                        Versions = new HashSet<int> { 4, 8, 16, 32, 64 }
                    },
                    new DataColumn
                    {
                        SourceName = "D_CHEESE",
                        DestinationName = "D_CHEESE",
                        Versions = new HashSet<int> { 4, 8, 16, 32, 64 }
                    },
                    new DataColumn
                    {
                        SourceName = "D_TOTAL",
                        DestinationName = "D_TOTAL",
                        Versions = new HashSet<int> { 4, 8, 16, 32, 64 }
                    },
                    new DataColumn
                    {
                        SourceName = "OILS",
                        DestinationName = "OILS",
                        Versions = new HashSet<int> { 4, 8, 16, 32, 64 }
                    },
                    new DataColumn
                    {
                        SourceName = "SOLID_FATS",
                        DestinationName = "SOLID_FATS",
                        Versions = new HashSet<int> { 4, 8, 16, 32, 64 }
                    },
                    new DataColumn
                    {
                        SourceName = "ADD_SUGARS",
                        DestinationName = "ADD_SUGARS",
                        Versions = new HashSet<int> { 4, 8, 16, 32, 64 }
                    },
                    new DataColumn
                    {
                        SourceName = "A_DRINKS",
                        DestinationName = "A_DRINKS",
                        Versions = new HashSet<int> { 4, 8, 16, 32, 64 }
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