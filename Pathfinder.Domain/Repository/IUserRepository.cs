using Pathfinder.Domain.Entities;

namespace Pathfinder.Domain.Repository
{
    public interface IUserRepository : IRepositoryBase<User>
    {
        /// <summary>
        /// Finds user by username and password
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        User Find(string username, string password);
    }
}