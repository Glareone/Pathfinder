namespace Pathfinder.Data
{
    public sealed class DataContext
    {
        /// <summary>
        /// Instance of <see cref="DataContext"/>
        /// </summary>
        public static readonly DataContext Instance = new DataContext();

        /// <summary>
        /// Private constructor
        /// </summary>
        private DataContext()
        {
        }

        /// <summary>
        /// File storage
        /// </summary>
        public IFileStorage FileStorage { get; set; }
    }
}