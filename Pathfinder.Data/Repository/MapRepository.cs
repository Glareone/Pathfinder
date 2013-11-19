using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;

using Pathfinder.Data.Builders;
using Pathfinder.Domain.Entities;
using Pathfinder.Domain.Repository;

using TiledSharp;

namespace Pathfinder.Data.Repository
{
    public class MapRepository : RepositoryBase<Map>, IMapRepository
    {
        /// <summary>
        /// Get all
        /// </summary>
        /// <returns></returns>
        public override List<Map> GetAll()
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// Loads <see cref="Map"/> by index
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public Map Load(int index)
        {
            using (var stream = Assembly.GetExecutingAssembly().GetManifestResourceStream(string.Format("Pathfinder.Data.Maps._{0}.data.tmx", index)))
            {
                if (stream == null)
                {
                    throw new InvalidOperationException("Loading data file failed. Path not found.");
                }

                var buffer = new byte[stream.Length];
                stream.Read(buffer, 0, buffer.Length);

                var dataFilePath = Path.GetTempFileName();

                File.WriteAllBytes(dataFilePath, buffer);

                return new MapBuilder(new TmxMap(dataFilePath)).Build();
            }
        }
    }
}