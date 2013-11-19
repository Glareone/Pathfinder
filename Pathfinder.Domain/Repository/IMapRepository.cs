using Pathfinder.Domain.Entities;

namespace Pathfinder.Domain.Repository
{
    public interface IMapRepository : IRepositoryBase<Map>
    {
        /// <summary>
        /// Loads <see cref="Map"/> by index
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        Map Load(int index);
    }
}