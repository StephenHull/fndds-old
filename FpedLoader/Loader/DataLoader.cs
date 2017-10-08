namespace FpedLoader.Loader
{
    using Base.Loader;
    using Model;
    using System.Data.OleDb;

    /// <summary>
    /// The class contains functionality for loading data from the source database into
    /// a destination database table.
    /// </summary>
    public abstract class DataLoader : BaseDataLoader
    {
        /// <summary>
        /// Constructs a new DataLoader object.
        /// </summary>
        /// <param name="version">The FNDDS version.</param>
        /// <param name="connection">The connection to the source database.</param>
        /// <param name="context">The destination database context.</param>
        public DataLoader(FnddsVersion version, OleDbConnection connection, FpedContext context)
        {
            FnddsVersion = version;
            Connection = connection;
            Context = context;
        }

        /// <summary>
        /// The source database connection.
        /// </summary>
        public new OleDbConnection Connection { get; private set; }

        /// <summary>
        /// The destination database context.
        /// </summary>
        public FpedContext Context { get; private set; }

        /// <summary>
        /// The FNDDS version.
        /// </summary>
        public new FnddsVersion FnddsVersion { get; private set; }
    }
}