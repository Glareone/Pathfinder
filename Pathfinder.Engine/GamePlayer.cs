using Pathfinder.Domain.Entities;

namespace Pathfinder.Engine
{
    public class GamePlayer
    {
        /// <summary>
        /// Person information
        /// </summary>
        public Person Person { get; set; }

        /// <summary>
        /// Bot implementation
        /// </summary>
        public Domain.Entities.Bot Bot { get; set; }
    }
}