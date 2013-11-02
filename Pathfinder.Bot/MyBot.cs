namespace Pathfinder.Bot
{
    public class MyBot : IBot
    {
        private ILocation previousLoc;

        public Direction DoTurn(IGameState state)
        {
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
                    previousLoc = destination;
                    return direction;
                }
            }

            return Direction.None;
        }
    }
}