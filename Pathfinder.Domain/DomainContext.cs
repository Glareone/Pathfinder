namespace Pathfinder.Domain
{
    public sealed class DomainContext
    {
        /// <summary>
        /// Instance of <see cref="DomainContext"/>
        /// </summary>
        public static readonly DomainContext Instance = new DomainContext();

        /// <summary>
        /// Private constructor
        /// </summary>
        private DomainContext()
        {
        }

        /// <summary>
        /// Repository factory
        /// </summary>
        public IRepositoryFactory RepositoryFactory { get; set; }
    }
}