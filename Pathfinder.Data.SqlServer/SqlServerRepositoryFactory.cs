using Pathfinder.Data.SqlServer.Repository;
using Pathfinder.Domain.Repository;

namespace Pathfinder.Data.SqlServer
{
    public class SqlServerRepositoryFactory : RepositoryFactory
    {
        /// <summary>
        /// Gets user repository
        /// </summary>
        /// <returns></returns>
        public override IUserRepository GetUserRepository()
        {
            return new UserRepository();
        }

        /// <summary>
        /// Gets person repository
        /// </summary>
        /// <returns></returns>
        public override IPersonRepository GetPersonRepository()
        {
            return new PersonRepository();
        }

        /// <summary>
        /// Gets bot repository
        /// </summary>
        /// <returns></returns>
        public override IBotRepository GetBotRepository()
        {
            return new BotRepository();
        }

        /// <summary>
        /// Gets Map repository
        /// </summary>
        /// <returns></returns>
        public override IMapRepository GetMapRepository()
        {
            return new MapRepository();
        }
    }
}