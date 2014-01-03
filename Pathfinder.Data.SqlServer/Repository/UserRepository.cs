using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;

using Pathfinder.Domain.Entities;
using Pathfinder.Domain.Repository;

namespace Pathfinder.Data.SqlServer.Repository
{
    public class UserRepository : RepositoryBase<User>, IUserRepository
    {
        /// <summary>
        /// Gets entity by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public override User Get(int id)
        {
            using (var context = new PathfinderContext())
            {
                return context.Users.Find(id);
            }
        }

        /// <summary>
        /// Get all
        /// </summary>
        /// <returns></returns>
        public override List<User> GetAll()
        {
            using (var context = new PathfinderContext())
            {
                return context.Users.ToList();
            }
        }

        /// <summary>
        /// Saves entity
        /// </summary>
        /// <param name="user"></param>
        public override void Save(User user)
        {
            using (var context = new PathfinderContext())
            {
                context.Users.AddOrUpdate(user);
                context.SaveChanges();
            }
        }

        /// <summary>
        /// Finds user by username and password
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public User Find(string username, string password)
        {
            using (var context = new PathfinderContext())
            {
                return context.Users.FirstOrDefault(x => x.Username == username && x.Password == password);
            }
        }
    }
}