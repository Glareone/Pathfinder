namespace Pathfinder.Bot
{
    public class MyBot : IBot
    {
        private Location previousLoc;

        /// <summary>
        /// Cached map
        /// </summary>
        protected int[,] Map { get; set; }

        /// <summary>
        /// Loading step
        /// </summary>
        /// <param name="state"></param>
        public void Load(IGameState state)
        {
            Map = new int[state.Width, state.Height];
        }

        /// <summary>
        /// Do turn
        /// </summary>
        /// <param name="state"></param>
        /// <returns></returns>
        public Direction DoTurn(IGameState state)
        {
            int minCostDestination = int.MaxValue;
            Direction minCostDirection = Direction.None;

            // try all the directions
            foreach (Direction direction in state.Aim.Keys)
            {
                // check if we have time left
                if (state.TimeRemaining < 10)
                {
                    return Direction.None;
                }

                var destination = state.GetDestination(state.Me, direction);
                if (destination.Equals(previousLoc))
                {
                    continue;
                }

                if (state.IsPassable(destination))
                {
                    var destinationCost = state.GetPassCost(destination);

                    if (minCostDestination > destinationCost)
                    {
                        minCostDestination = destinationCost;
                        minCostDirection = direction;
                    }

                    previousLoc = destination;
                }
            }

            return minCostDirection;
        }

        /// <summary>
        /// Unload and free all resources
        /// </summary>
        public void Unload()
        {
            Map = null;
        }
    }
}