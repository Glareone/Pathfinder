using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;

using Pathfinder.Domain.Entities;
using Pathfinder.Domain.Repository;

namespace Pathfinder.Data.SqlServer.Repository
{
    public class MapRepository : RepositoryBase<Map>, IMapRepository
    {
        /// <summary>
        /// Gets entity by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public override Map Get(int id)
        {
            using (var context = new PathfinderContext())
            {
                return context.Maps.Find(id);
            }
        }

        /// <summary>
        /// Get all
        /// </summary>
        /// <returns></returns>
        public override List<Map> GetAll()
        {
            using (var context = new PathfinderContext())
            {
                return context.Maps.ToList();
            }
        }

        /// <summary>
        /// Saves entity
        /// </summary>
        /// <param name="map"></param>
        public override void Save(Map map)
        {
            using (var context = new PathfinderContext())
            {
                context.Maps.AddOrUpdate(map);
                context.SaveChanges();
            }
        }

        /// <summary>
        /// Deletes map
        /// </summary>
        /// <param name="map"></param>
        public void Delete(Map map)
        {
            Delete(map.Id);
        }

        /// <summary>
        /// Deletes map
        /// </summary>
        /// <param name="id"></param>
        public void Delete(int id)
        {
            using (var context = new PathfinderContext())
            {
                var c = new Map { Id = id };
                context.Entry(c).State = EntityState.Deleted;
                context.SaveChanges();
            }
        }
    }
}