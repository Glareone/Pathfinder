using Pathfinder.Domain.Entities;

namespace Pathfinder.Domain.Repository
{
    public interface IMapRepository : IRepositoryBase<Map>
    {
        /// <summary>
        /// Deletes map
        /// </summary>
        /// <param name="map"></param>
        void Delete(Map map);

        /// <summary>
        /// Deletes map
        /// </summary>
        /// <param name="id"></param>
        void Delete(int id);
    }
}