using System;
using System.Reflection;
using Pathfinder.Domain.Repository;

namespace Pathfinder.Data.Repository
{
    public class ContentRepository : IContentRepository
    {
        /// <summary>
        /// Gets image by path
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public byte[] GetImage(string path)
        {
            using (var stream = Assembly.GetExecutingAssembly().GetManifestResourceStream(string.Format("Pathfinder.Data.Icons.{0}", path)))
            {
                if (stream == null)
                {
                    throw new InvalidOperationException("Loading image failed. Path not found.");
                }

                var buffer = new byte[stream.Length];
                stream.Read(buffer, 0, buffer.Length);

                return buffer;
            }
        }
    }
}