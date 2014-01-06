using Pathfinder.Domain.Entities;

namespace Pathfinder.Engine
{
    public class GameEngineParameters
    {
        /// <summary>
        /// Map to play
        /// </summary>
        public Map Map { get; set; }

        /// <summary>
        /// GamePlayers collection
        /// </summary>
        public GamePlayer[] GamePlayers { get; set; }
    }
}