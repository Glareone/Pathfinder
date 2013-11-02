using System;
using System.Collections.Generic;
using Pathfinder.Bot;

namespace Pathfinder.Domain
{
    public class GameState : IGameState
    {
        public static IDictionary<Direction, ILocation> aim = new Dictionary<Direction, ILocation> {
            { Direction.None, new Location(0, 0)},
            { Direction.North, new Location(-1, 0)},
            { Direction.East, new Location(0, 1)},
            { Direction.South, new Location(1, 0)},
            { Direction.West, new Location(0, -1)}
        }; 

        /// <summary>
        /// Initializes a new instance of <see cref="GameState"/> class
        /// </summary>
        public GameState(Tile[,] map, ILocation startPoint, ILocation endPoint, int turnTime, int defaultViewRadius)
        {
            Map = map;
            StartPoint = startPoint;
            EndPoint = endPoint;
            TurnTime = turnTime;
            DefaultViewRadius = defaultViewRadius;

            Visible = new List<ILocation>();
            Enemies = new List<ILocation>();
            Artifacts = new List<ILocation>();
        }

        protected Tile[,] Map { get; set; }
        /// <summary>
        /// Gets the width of the map.
        /// </summary>
        public int Width
        {
            get
            {
                return Map.GetLength(0);
            }
        }

        /// <summary>
        /// Gets the height of the map.
        /// </summary>
        public int Height
        {
            get
            {
                return Map.GetLength(1);
            }
        }

        /// <summary>
        /// Gets the allowed turn time remaining in milliseconds.
        /// </summary>
        public int TimeRemaining
        {
            get
            {
                TimeSpan timeSpent = DateTime.Now - TurnStart;
                return TurnTime - (int)timeSpent.TotalMilliseconds;
            }
        }

        /// <summary>
        /// Gets turn start time
        /// </summary>
        protected DateTime TurnStart { get; private set; }

        /// <summary>
        /// Gets turn time
        /// </summary>
        protected int TurnTime { get; private set;}

        /// <summary>
        /// View radius
        /// </summary>
        public int DefaultViewRadius { get; private set; }

        /// <summary>
        /// Start point (entry)
        /// </summary>
        public ILocation StartPoint { get; private set; }

        /// <summary>
        /// End point (exit)
        /// </summary>
        public ILocation EndPoint { get; private set; }

        /// <summary>
        /// Gets your current location.
        /// </summary>
        public IPlayer Me
        {
            get;set;
        }

        /// <summary>
        /// Gets a list of visible tiles.
        /// </summary>
        public IList<ILocation> Visible
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets a list of currently visible players.
        /// </summary>
        public IList<ILocation> Enemies
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets a list of artifact tiles visible this turn.
        /// </summary>
        public IList<ILocation> Artifacts
        {
            get;
            private set;
        }

        /// <summary>
        /// Calculates visible tiles
        /// </summary>
        protected void CalculateVisibleTimes()
        {
            var viewRadius = DefaultViewRadius + Me.ViewRadiusBonus;

            int squares = (int)Math.Floor(Math.Sqrt(viewRadius));
            for (int r = -1 * squares; r <= squares; ++r)
            {
                for (int c = -1 * squares; c <= squares; ++c)
                {
                    int square = r * r + c * c;
                    if (square < viewRadius)
                    {
                        Visible.Add(new Location(r, c));
                    }
                }
            }
        }

        /// <summary>
        /// Gets whether <paramref name="location"/> is passable or not.
        /// </summary>
        /// <param name="location">The location to check.</param>
        /// <returns><c>true</c> if the location is not water, <c>false</c> otherwise.</returns>
        public bool IsPassable(ILocation location)
        {
            return Map[location.Row, location.Col].Cost.HasValue;
        }

        /// <summary>
        /// Gets cost of moving on this location
        /// </summary>
        /// <param name="location"></param>
        /// <returns></returns>
        public int GetPassCost(ILocation location)
        {
            return Map[location.Row, location.Col].Cost.GetValueOrDefault(int.MaxValue);
        }

        /// <summary>
        /// Checks if artifact
        /// </summary>
        /// <param name="loc"></param>
        /// <returns></returns>
        public bool IsArtifact(ILocation loc)
        {
            return Artifacts.Contains(loc);
        }

        public bool IsExit(ILocation location)
        {
            return StartPoint.Equals(location);
        }

        /// <summary>
        /// Gets destination
        /// </summary>
        /// <param name="loc"></param>
        /// <param name="direction"></param>
        /// <returns></returns>
        public ILocation GetDestination(ILocation loc, Direction direction)
        {
            var delta = Aim[direction];

            return new Location(loc.Row + delta.Row, loc.Col + delta.Col);
        }

        /// <summary>
        /// Gets the distance between <paramref name="loc1"/> and <paramref name="loc2"/>.
        /// </summary>
        /// <param name="loc1">The first location to measure with.</param>
        /// <param name="loc2">The second location to measure with.</param>
        /// <returns>The distance between <paramref name="loc1"/> and <paramref name="loc2"/></returns>
        public int GetDistance(ILocation loc1, ILocation loc2)
        {
            int d_row = Math.Abs(loc1.Row - loc2.Row);
            d_row = Math.Min(d_row, Height - d_row);

            int d_col = Math.Abs(loc1.Col - loc2.Col);
            d_col = Math.Min(d_col, Width - d_col);

            return d_row + d_col;
        }

        /// <summary>
        /// Gets aims
        /// </summary>
        public IDictionary<Direction, ILocation> Aim
        {
            get { return aim; }
        }

        /// <summary>
        /// Checks if visible
        /// </summary>
        /// <param name="loc"></param>
        /// <returns></returns>
        public bool IsVisible(ILocation loc)
        {
            return Visible.Contains(loc);
        }

        /// <summary>
        /// Checks if enemy
        /// </summary>
        /// <param name="loc"></param>
        /// <returns></returns>
        public bool IsEnemy(ILocation loc)
        {
            return Enemies.Contains(loc);
        }

        /// <summary>
        /// Clears state
        /// </summary>
        public GameState ClearState()
        {
            Visible.Clear();
            Enemies.Clear();
            Artifacts.Clear();

            return this;
        }

        /// <summary>
        /// Sets player's location
        /// </summary>
        /// <param name="player"></param>
        public GameState SetPlayerLocation(IPlayer player)
        {
            Me = player;

            return this;
        }

        /// <summary>
        /// Adds enemy
        /// </summary>
        /// <param name="enemy"></param>
        /// <returns></returns>
        public GameState AddEnemy(IPlayer enemy)
        {
            Enemies.Add(enemy);

            return this;
        }

        /// <summary>
        /// Adds artifact
        /// </summary>
        /// <param name="artifact"></param>
        /// <returns></returns>
        public GameState AddArtifact(IArtifact artifact)
        {
            Artifacts.Add(artifact);

            return this;
        }

        /// <summary>
        /// Starts turn
        /// </summary>
        public GameState StartTurn()
        {
            CalculateVisibleTimes();

            TurnStart = DateTime.Now;

            return this;
        }
    }

}