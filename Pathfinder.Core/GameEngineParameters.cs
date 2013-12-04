using System.Collections.Generic;

using Pathfinder.Bot;
using Pathfinder.Domain.Entities;

namespace Pathfinder.Core
{
    public class GameEngineParameters
    {
        /// <summary>
        /// Map to play
        /// </summary>
        public Map Map { get; set; }

        /// <summary>
        /// Players collection
        /// </summary>
        public GamePlayer[] Players { get; set; }
    }
}