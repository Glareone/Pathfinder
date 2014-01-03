using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;

using Pathfinder.Domain.Entities;
using Pathfinder.Domain.Repository;

namespace Pathfinder.Data.SqlServer.Repository
{
    public class BotRepository : RepositoryBase<Bot>, IBotRepository
    {
        /// <summary>
        /// Gets entity by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public override Bot Get(int id)
        {
            using (var context = new PathfinderContext())
            {
                return context.Bots.Find(id);
            }
        }

        /// <summary>
        /// Get all
        /// </summary>
        /// <returns></returns>
        public override List<Bot> GetAll()
        {
            using (var context = new PathfinderContext())
            {
                return context.Bots.ToList();
            }
        }

        /// <summary>
        /// Saves entity
        /// </summary>
        /// <param name="bot"></param>
        public override void Save(Bot bot)
        {
            using (var context = new PathfinderContext())
            {
                context.Bots.AddOrUpdate(bot);
                context.SaveChanges();
            }
        }

        /// <summary>
        /// Gets collection of <see cref="Pathfinder.Domain.Entities.Bot"/>
        /// </summary>
        /// <param name="person"></param>
        /// <returns></returns>
        public List<Bot> GetBots(Person person)
        {
            using (var context = new PathfinderContext())
            {
                return context.Bots.Where(x => x.PersonId == person.Id).ToList();
            }
        }
    }
}