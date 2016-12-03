using FnddsLoader.Model;

namespace FnddsLoader.Utility
{
    /// <summary>
    /// This class contains utility methods for the FNDDS version.
    /// </summary>
    public static class VersionUtility
    {
        /// <summary>
        /// Returns the FNDDS version that matches the specified ID (or null if a match
        /// cannot be found).
        /// </summary>
        /// <param name="id">The version ID.</param>
        /// <returns>The FNDDS version.</returns>
        public static FnddsVersion GetVersionFromId(int id)
        {
            FnddsVersion version = null;

            switch (id)
            {
                case 1:
                    version = new FnddsVersion
                    {
                        Id = id,
                        BeginYear = 2001,
                        EndYear = 2002,
                        Major = 1,
                        Minor = 0
                    };
                    break;
                case 2:
                    version = new FnddsVersion
                    {
                        Id = id,
                        BeginYear = 2003,
                        EndYear = 2004,
                        Major = 2,
                        Minor = 0
                    };
                    break;
                case 4:
                    version = new FnddsVersion
                    {
                        Id = id,
                        BeginYear = 2005,
                        EndYear = 2006,
                        Major = 3,
                        Minor = 0
                    };
                    break;
                case 8:
                    version = new FnddsVersion
                    {
                        Id = id,
                        BeginYear = 2007,
                        EndYear = 2008,
                        Major = 4,
                        Minor = 1
                    };
                    break;
                case 16:
                    version = new FnddsVersion
                    {
                        Id = id,
                        BeginYear = 2009,
                        EndYear = 2010,
                        Major = 5,
                        Minor = 0
                    };
                    break;
                case 32:
                    version = new FnddsVersion
                    {
                        Id = id,
                        BeginYear = 2011,
                        EndYear = 2012,
                        Major = 6,
                        Minor = 0
                    };
                    break;
                case 64:
                    version = new FnddsVersion
                    {
                        Id = id,
                        BeginYear = 2013,
                        EndYear = 2014,
                        Major = 7,
                        Minor = 0
                    };
                    break;
            }

            return version;
        }
    }
}