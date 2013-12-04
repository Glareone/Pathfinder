using System;

using Pathfinder.Domain.Entities;

namespace Pathfinder.Domain.Repository
{
    public interface IPersonRepository : IRepositoryBase<Person>
    {
        /// <summary>
        /// Finds person username and password
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        Person Find(string username, string password);

        /// <summary>
        /// Finds person username
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        Person Find(string username);

        /// <summary>
        /// Finds person by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Person Find(Guid id);

        /// <summary>
        /// Saves person
        /// </summary>
        /// <param name="person"></param>
        void Save(Person person);
    }
}