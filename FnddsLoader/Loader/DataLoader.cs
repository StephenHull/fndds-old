namespace FnddsLoader.Loader
{
    using Base.Loader;
    using Model;
    using System.Data.OleDb;

    public abstract class DataLoader : BaseDataLoader
    {
        /// <summary>
        /// Constructs a new DataLoader object.
        /// </summary>
        /// <param name="version">The FNDDS version.</param>
        /// <param name="connection">The connection to the source database.</param>
        /// <param name="context">The destination database context.</param>
        public DataLoader(FnddsVersion version, OleDbConnection connection, FnddsContext context)
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
        public new FnddsContext Context { get; private set; }

        /// <summary>
        /// The FNDDS version.
        /// </summary>
        public new FnddsVersion FnddsVersion { get; private set; }
    }
}