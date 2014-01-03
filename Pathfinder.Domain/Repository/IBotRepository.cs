using System.Collections.Generic;

using Pathfinder.Domain.Entities;

namespace Pathfinder.Domain.Repository
{
    public interface IBotRepository : IRepositoryBase<Entities.Bot>
    {
        /// <summary>
        /// Gets collection of <see cref="Entities.Bot"/>
        /// </summary>
        /// <param name="person"></param>
        /// <returns></returns>
        List<Entities.Bot> GetBots(Person person);
    }
}