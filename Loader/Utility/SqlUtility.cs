using FnddsLoader.Loader;
using System.Collections.Generic;
using System.Text;

namespace FnddsLoader.Utility
{
    /// <summary>
    /// This class contains utility methods for building SQL statements.
    /// </summary>
    public static class SqlUtility
    {
        /// <summary>
        /// Returns a SQL statement for retrieving data from the source database.
        /// </summary>
        /// <param name="tableName">The table name.</param>
        /// <param name="columns">The list of database columns.</param>
        /// <returns>A SQL startment with a SELECT clause and an optional ORDER BY clause.</returns>
        public static string GetSql(string tableName, IEnumerable<DataColumn> columns)
        {

            var selectColumns = new StringBuilder();
            var orderByColumns = new StringBuilder();

            foreach (DataColumn column in columns)
            {
                if (selectColumns.Length > 0)
                {
                    selectColumns.Append(", ");
                }

                selectColumns.Append(column.SourceName);

                if (column.IsOrderBy)
                {
                    if (orderByColumns.Length > 0)
                    {
                        orderByColumns.Append(", ");
                    }

                    orderByColumns.Append(column.SourceName);
                }
            }

            if (orderByColumns.Length > 0)
            {
                return "SELECT " + selectColumns + " FROM " + tableName + " ORDER BY " + orderByColumns;
            }

            return "SELECT " + selectColumns + " FROM " + tableName;
        }
    }
}