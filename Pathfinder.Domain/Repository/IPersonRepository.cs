using Pathfinder.Domain.Entities;

namespace Pathfinder.Domain.Repository
{
    public interface IPersonRepository : IRepositoryBase<Person>
    {
        /// <summary>
        /// Gets person by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Person Get(int id);
    }
}