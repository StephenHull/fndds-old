namespace Base.Loader
{
    using log4net;
    using Model;
    using System;
    using System.Collections.Generic;
    using System.Data.OleDb;
    using System.Threading.Tasks;
    using Utility;

    /// <summary>
    /// The class contains functionality for loading data from the source database into
    /// a destination database table.
    /// </summary>
    public abstract class BaseDataLoader
    {
        /// <summary>
        /// The default batch size for the data loader.
        /// </summary>
        public const int BatchSize = 1000; // TODO Make this configurable

        /// <summary>
        /// The logger class.
        /// </summary>
        private readonly ILog _logger = LogManager.GetLogger(typeof(BaseDataLoader));

        /// <summary>
        /// Gets the list of database column descriptions.
        /// </summary>
        public abstract IEnumerable<DataColumn> Columns { get; }

        /// <summary>
        /// The source database connection.
        /// </summary>
        public OleDbConnection Connection { get; private set; }

        /// <summary>
        /// Creates records in the destination database based on data from the source
        /// database.
        /// </summary>
        /// <param name="columns">The database column descriptions.</param>
        /// <param name="reader">The source database data reader.</param>
        /// <returns>The number of records created.</returns>
        public abstract Task<int> CreateRecordsAsync(IEnumerable<DataColumn> columns, OleDbDataReader reader);

        /// <summary>
        /// The FNDDS version.
        /// </summary>
        public IFnddsVersion FnddsVersion { get; private set; }

        /// <summary>
        /// Load the data from the source database into the destination database.
        /// </summary>
        /// <returns>The number of records created.</returns>
        public async Task<int> LoadAsync()
        {
            var columns = new List<DataColumn>();

            foreach (var column in Columns)
            {
                if (column.Versions.Contains(FnddsVersion.Id))
                {
                    columns.Add(column);
                }
            }

            var recordCount = 0;

            if (columns.Count > 0)
            {
                var sql = SqlUtility.GetSql(TableName, columns);

                _logger.Debug(sql);

                using (var command = new OleDbCommand(sql, Connection))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        recordCount = await CreateRecordsAsync(columns, reader);
                    }
                }
            }

            return recordCount;
        }

        /// <summary>
        /// Sets the model values using the data from the source database.
        /// </summary>
        /// <param name="columns">The database column descriptions.</param>
        /// <param name="reader">The source database data reader.</param>
        /// <param name="model">The data model.</param>
        public void SetModelValues(IEnumerable<DataColumn> columns, OleDbDataReader reader, object model)
        {
            var index = 0;

            foreach (DataColumn column in columns)
            {
                if (column.IsIgnored)
                {
                    continue;
                }

                var value = reader.GetValue(index++);
                if (value != null)
                {
                    var type = model.GetType();
                    var property = type.GetProperty(column.DestinationName);
                    var propertyType = property.PropertyType;

                    if (propertyType == typeof(DateTime))
                    {
                        DateTime dateTimeValue;
                        if (DateTime.TryParse(value.ToString(), out dateTimeValue) == false)
                        {
                            var message = string.Format("Unable to parse date/time value {0}.", value);
                            throw new Exception(message);
                        }

                        property.SetValue(model, dateTimeValue);
                    }
                    else if (propertyType == typeof(decimal) || propertyType == typeof(decimal?))
                    {
                        decimal decimalValue;
                        if (decimal.TryParse(value.ToString(), out decimalValue) == false)
                        {
                            var message = string.Format("Unable to parse decimal value {0}.", value);
                            throw new Exception(message);
                        }

                        property.SetValue(model, decimalValue);
                    }
                    else if (propertyType == typeof(int) || propertyType == typeof(int?))
                    {
                        int intValue;
                        if (int.TryParse(value.ToString(), out intValue) == false)
                        {
                            var message = string.Format("Unable to parse integer value {0}.", value);
                            throw new Exception(message);
                        }

                        property.SetValue(model, intValue);
                    }
                    else if (propertyType == typeof(string))
                    {
                        var strValue = value.ToString();
                        if (string.IsNullOrEmpty(strValue) == false)
                        {
                            property.SetValue(model, strValue);
                        }
                    }
                    else
                    {
                        property.SetValue(model, value);
                    }
                }
            }
        }

        /// <summary>
        /// Gets the source database table name.
        /// </summary>
        public abstract string TableName { get; }
    }
}