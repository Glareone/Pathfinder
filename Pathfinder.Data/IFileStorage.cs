using System.IO;

namespace Pathfinder.Data
{
    public interface IFileStorage
    {
        /// <summary>
        /// Saves file into storage
        /// </summary>
        /// <param name="path"></param>
        /// <param name="file"></param>
        void Save(string path, FileInfo file);

        /// <summary>
        /// Saves file into storage
        /// </summary>
        /// <param name="path"></param>
        /// <param name="stream"></param>
        void Save(string path, Stream stream);

        /// <summary>
        /// Loads file from storage
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        FileInfo Load(string path);
    }
}