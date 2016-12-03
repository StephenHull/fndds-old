using FnddsLoader.Model;
using log4net;
using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Threading.Tasks;

namespace FnddsLoader.Loader.Tables
{
    /// <summary>
    /// This class contains functionaility for loading data for the FNDDS/SR links
    /// table.
    /// </summary>
    public class FNDDSSRLinksLoader : DataLoader
    {
        /// <summary>
        /// The table name in the source database.
        /// </summary>
        private const string SourceTableName = "FNDDSSRLinks";

        /// <summary>
        /// The logger class.
        /// </summary>
        private readonly ILog _logger = LogManager.GetLogger(typeof(FNDDSSRLinksLoader));

        /// <summary>
        /// True if the logger is debug endabled; otherwise, false.
        /// </summary>
        private bool _isDebugEnabled = false;

        /// <summary>
        /// Constructs a new FNDDSSRLinksLoader object.
        /// </summary>
        /// <param name="version">The FNDDS version.</param>
        /// <param name="connection">The connection to the source database.</param>
        /// <param name="context">The destination database context.</param>
        public FNDDSSRLinksLoader(FnddsVersion version, OleDbConnection connection, FnddsContext context)
            : base(version, connection, context)
        {
            _isDebugEnabled = _logger.IsDebugEnabled;
        }

        /// <inheritdoc />
        public override async Task<int> CreateRecordsAsync(IEnumerable<DataColumn> columns, OleDbDataReader reader)
        {
            var srLinks = new List<FnddsSrLinks>();

            var recordCount = 0;
            while (reader.Read())
            {
                var srLink = new FnddsSrLinks
                {
                    Version = FnddsVersion.Id,
                    Created = DateTime.Now
                };

                SetModelValues(columns, reader, srLink);

                srLinks.Add(srLink);

                if (_isDebugEnabled)
                {
                    _logger.DebugFormat("Table: {0}, Food code: {1}, Sequence: {2}", SourceTableName, srLink.FoodCode, srLink.SeqNum);
                }

                if (srLinks.Count > BatchSize)
                {
                    Context.FnddsSrLinks.AddRange(srLinks);

                    await Context.SaveChangesAsync();

                    srLinks.Clear();
                }

                recordCount++;
            }

            if (srLinks.Count > 0)
            {
                Context.FnddsSrLinks.AddRange(srLinks);

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
                        SourceName = "[Seq num]",
                        DestinationName = "SeqNum",
                        IsOrderBy = true,
                        Versions = new HashSet<int> { 1, 2, 4, 8, 16, 32, 64 }
                    },
                    new DataColumn
                    {
                        SourceName = "[SR code]",
                        DestinationName = "SrCode",
                        Versions = new HashSet<int> { 1, 2, 4, 8, 16, 32, 64 }
                    },
                    new DataColumn
                    {
                        SourceName = "[SR description]",
                        DestinationName = "SrDescription",
                        Versions = new HashSet<int> { 1, 2, 4, 8, 16, 32, 64 }
                    },
                    new DataColumn
                    {
                        SourceName = "Amount",
                        DestinationName = "Amount",
                        Versions = new HashSet<int> { 1, 2, 4, 8, 16, 32, 64 }
                    },
                    new DataColumn
                    {
                        SourceName = "Measure",
                        DestinationName = "Measure",
                        Versions = new HashSet<int> { 1, 2, 4, 8, 16, 32, 64 }
                    },
                    new DataColumn
                    {
                        SourceName = "[Portion code]",
                        DestinationName = "PortionCode",
                        Versions = new HashSet<int> { 1, 2, 4, 8, 16, 32, 64 }
                    },
                    new DataColumn
                    {
                        SourceName = "[Retention code]",
                        DestinationName = "RetentionCode",
                        Versions = new HashSet<int> { 1, 2, 4, 8, 16, 32, 64 }
                    },
                    new DataColumn
                    {
                        SourceName = "Flag",
                        DestinationName = "Flag",
                        Versions = new HashSet<int> { 1, 2, 4, 8, 16, 32, 64 }
                    },
                    new DataColumn
                    {
                        SourceName = "Weight",
                        DestinationName = "Weight",
                        Versions = new HashSet<int> { 1, 2, 4, 8, 16, 32, 64 }
                    },
                    new DataColumn
                    {
                        SourceName = "[Change type to SR Code]",
                        DestinationName = "ChangeTypeToSrCode",
                        Versions = new HashSet<int> { 1, 2, 4, 8, 16, 32 }
                    },
                    new DataColumn
                    {
                        SourceName = "[Change type to weight]",
                        DestinationName = "ChangeTypeToWeight",
                        Versions = new HashSet<int> { 1, 2, 4, 8, 16, 32 }
                    },
                    new DataColumn
                    {
                        SourceName = "[Change type to retn code]",
                        DestinationName = "ChangeTypeToRetnCode",
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