using System;
using System.IO;
using System.Web;

using Pathfinder.Data;

namespace Pathfinder.Web.UI.Data
{
    public class AppDataFileStorage : IFileStorage
    {
        /// <summary>
        /// Saves file into storage
        /// </summary>
        /// <param name="path"></param>
        /// <param name="file"></param>
        public void Save(string path, FileInfo file)
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// Saves file into storage
        /// </summary>
        /// <param name="path"></param>
        /// <param name="stream"></param>
        public void Save(string path, Stream stream)
        {
            var pathMap = PathMap.ToMap(path);
            var targetDirectory = Path.Combine(GetStorageDirectory(), pathMap.Directory);
            if (!Directory.Exists(targetDirectory))
            {
                Directory.CreateDirectory(targetDirectory);
            }

            using (var fileStream = File.Create(Path.Combine(targetDirectory, pathMap.Filename)))
            {
                stream.CopyTo(fileStream);
            }
        }

        /// <summary>
        /// Loads file from storage
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public FileInfo Load(string path)
        {
            var pathMap = PathMap.ToMap(path);

            var fileDirectory = Path.Combine(GetStorageDirectory(), pathMap.Directory);
            if (!Directory.Exists(fileDirectory))
            {
                Directory.CreateDirectory(fileDirectory);
            }

            var filePath = Path.Combine(fileDirectory, pathMap.Filename);

            return new FileInfo(filePath);
        }

        /// <summary>
        /// Gets storage directory
        /// </summary>
        /// <returns></returns>
        protected string GetStorageDirectory()
        {
            return Path.Combine(HttpContext.Current.Server.MapPath("~/App_Data"), "Repository");
        }
    }
}