namespace FnddsLoader.Utility
{
    using System;
    using System.Diagnostics;
    using System.IO;
    using System.Net;
    using System.Reflection;

    /// <summary>
    /// 
    /// </summary>
    public static class FileUtility
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static string GetBaseFolder()
        {
            // Get the location the assembly resides on disk
            var location = Assembly.GetExecutingAssembly().CodeBase;

            // Get the base directory URI
            var directoryUri = Path.GetDirectoryName(location);

            // Get the base folder path
            var localPath = new Uri(directoryUri).LocalPath;

            return localPath;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="url"></param>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public static void DownloadFile(string url, string fileName)
        {
            DeleteFile(fileName);

            try
            {
                using (WebClient webClient = new WebClient())
                {
                    webClient.DownloadFile(new Uri(url), fileName);
                }
            }
            catch (Exception e)
            {
                Debug.Print(e.StackTrace);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="fileName"></param>
        private static void DeleteFile(string fileName)
        {
            if (File.Exists(fileName))
            {
                File.Delete(fileName);
            }
        }
    }
}