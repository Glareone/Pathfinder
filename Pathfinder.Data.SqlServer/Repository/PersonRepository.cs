using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;

using Pathfinder.Domain.Entities;
using Pathfinder.Domain.Repository;

namespace Pathfinder.Data.SqlServer.Repository
{
    public class PersonRepository : RepositoryBase<Person>, IPersonRepository
    {
        /// <summary>
        /// Get all
        /// </summary>
        /// <returns></returns>
        public override List<Person> GetAll()
        {
            using(var context = new PathfinderContext())
            {
                return context.Persons.ToList();
            }
        }

        /// <summary>
        /// Finds person username and password
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public Person Find(string username, string password)
        {
            using (var context = new PathfinderContext())
            {
                return context.Persons.Include(x => x.Bots).FirstOrDefault(x => x.Username == username && x.Password == password);
            }
        }

        /// <summary>
        /// Gets person by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Person Get(int id)
        {
            using (var context = new PathfinderContext())
            {
                return context.Persons.Include(x => x.Bots).Single(x => x.Id == id);
            }
        }

        /// <summary>
        /// Saves person
        /// </summary>
        /// <param name="person"></param>
        public void Save(Person person)
        {
            using (var context = new PathfinderContext())
            {
                context.Persons.AddOrUpdate(person);
                context.SaveChanges();
            }
        }
    }
}