using Pathfinder.Data.SqlServer.Repository;
using Pathfinder.Domain.Repository;

namespace Pathfinder.Data.SqlServer
{
    public class SqlServerRepositoryFactory : RepositoryFactory
    {
        /// <summary>
        /// Gets person repository
        /// </summary>
        /// <returns></returns>
        public override IPersonRepository GetPersonRepository()
        {
            return new PersonRepository();
        }
    }
}