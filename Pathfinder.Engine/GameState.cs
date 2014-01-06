using System;
using System.Collections.Generic;

using Pathfinder.Bot;
using Pathfinder.Core.Tiles;

namespace Pathfinder.Engine
{
    public class GameState : IGameState
    {
        public static IDictionary<Direction, Location> aim = new Dictionary<Direction, Location> {
            { Direction.None, new Location(0, 0)},
            { Direction.North, new Location(-1, 0)},
            { Direction.East, new Location(0, 1)},
            { Direction.South, new Location(1, 0)},
            { Direction.West, new Location(0, -1)}
        }; 

        /// <summary>
        /// Initializes a new instance of <see cref="GameState"/> class
        /// </summary>
        public GameState(Tile[,] map, Location startPoint, Location endPoint, int loadTime, int turnTime, int viewRadius, int turns)
        {
            Map = map;
            StartPoint = startPoint;
            EndPoint = endPoint;
            LoadTime = loadTime;
            TurnTime = turnTime;
            ViewRadius = viewRadius;
            Turns = turns;

            Visible = new List<Location>();
            Enemies = new List<Location>();
            Artifacts = new List<Location>();
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
        /// Gets the allowed loading time remaining in milliseconds
        /// </summary>
        public int LoadingTimeRemaining
        {
            get
            {
                TimeSpan timeSpent = DateTime.Now - LoadStart;
                return LoadTime - (int)timeSpent.TotalMilliseconds;
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
        /// Current turn
        /// </summary>
        public int Turn { get; private set; }

        /// <summary>
        /// Maximum available turns count
        /// </summary>
        public int Turns { get; set; }

        /// <summary>
        /// Gets turn when loading started
        /// </summary>
        public DateTime LoadStart { get; private set; }

        /// <summary>
        /// Gets turn start time
        /// </summary>
        protected DateTime TurnStart { get; private set; }

        /// <summary>
        /// Gets load time
        /// </summary>
        protected int LoadTime { get; private set; }

        /// <summary>
        /// Gets turn time
        /// </summary>
        protected int TurnTime { get; private set;}

        /// <summary>
        /// View radius
        /// </summary>
        public int ViewRadius { get; private set; }

        /// <summary>
        /// Start point (entry)
        /// </summary>
        public Location StartPoint { get; private set; }

        /// <summary>
        /// End point (exit)
        /// </summary>
        public Location EndPoint { get; private set; }

        /// <summary>
        /// Gets your current location.
        /// </summary>
        public Bot.Player Player
        {
            get;set;
        }

        /// <summary>
        /// Gets a list of visible tiles.
        /// </summary>
        public IList<Location> Visible
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets a list of currently visible players.
        /// </summary>
        public IList<Location> Enemies
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets a list of artifact tiles visible this turn.
        /// </summary>
        public IList<Location> Artifacts
        {
            get;
            private set;
        }

        /// <summary>
        /// Calculates visible tiles
        /// </summary>
        protected void CalculateVisibleTimes()
        {
            var viewRadius = ViewRadius + Player.ViewRadiusBonus;

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
        public bool IsPassable(Location location)
        {
            return Map[location.Row, location.Col].Cost != int.MaxValue;
        }

        /// <summary>
        /// Gets cost of moving on this location
        /// </summary>
        /// <param name="location"></param>
        /// <returns></returns>
        public int GetPassCost(Location location)
        {
            return Map[location.Row, location.Col].Cost;
        }

        /// <summary>
        /// Checks if artifact
        /// </summary>
        /// <param name="loc"></param>
        /// <returns></returns>
        public bool IsChest(Location loc)
        {
            return Artifacts.Contains(loc);
        }

        public bool IsExit(Location location)
        {
            return StartPoint.Equals(location);
        }

        /// <summary>
        /// Gets destination
        /// </summary>
        /// <param name="loc"></param>
        /// <param name="direction"></param>
        /// <returns></returns>
        public Location GetDestination(Location loc, Direction direction)
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
        public int GetDistance(Location loc1, Location loc2)
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
        public IDictionary<Direction, Location> Aim
        {
            get { return aim; }
        }

        /// <summary>
        /// Checks if visible
        /// </summary>
        /// <param name="loc"></param>
        /// <returns></returns>
        public bool IsVisible(Location loc)
        {
            return Visible.Contains(loc);
        }

        /// <summary>
        /// Checks if enemy
        /// </summary>
        /// <param name="loc"></param>
        /// <returns></returns>
        public bool IsEnemy(Location loc)
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
        public GameState SetPlayerLocation(Bot.Player player)
        {
            Player = player;

            return this;
        }

        /// <summary>
        /// Adds enemy
        /// </summary>
        /// <param name="enemy"></param>
        /// <returns></returns>
        public GameState AddEnemy(Bot.Player enemy)
        {
            Enemies.Add(enemy);

            return this;
        }

        /// <summary>
        /// Adds artifact
        /// </summary>
        /// <param name="artifact"></param>
        /// <returns></returns>
        public GameState AddArtifact(Chest artifact)
        {
            Artifacts.Add(artifact);

            return this;
        }

        public GameState Load()
        {
            LoadStart = DateTime.Now;

            return this;
        }

        /// <summary>
        /// Starts turn
        /// </summary>
        public GameState StartTurn()
        {
            CalculateVisibleTimes();

            Turn++;

            TurnStart = DateTime.Now;

            return this;
        }
    }

}