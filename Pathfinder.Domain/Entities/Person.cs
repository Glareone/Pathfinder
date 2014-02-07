using System;
using System.Collections.Generic;

using Pathfinder.Dependency;

namespace Pathfinder.Domain.Entities
{
    [Serializable]
    public class Person : DomainEntity
    {
        private List<Bot> _bots;

        /// <summary>
        /// First name
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Last name
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// Gets display name
        /// </summary>
        public string DisplayName
        {
            get
            {
                return string.Format("{0} {1}", FirstName, LastName);
            }
        }

        /// <summary>
        /// Bots collection
        /// </summary>
        public List<Bot> Bots
        {
            get
            {
                return _bots ?? (_bots = DI.Resolve<IRepositoryFactory>()
                    .GetBotRepository()
                    .GetBots(this));
            }
        }

        /// <summary>
        /// Saves instance
        /// </summary>
        public override void Save()
        {
            DI.Resolve<IRepositoryFactory>()
                .GetPersonRepository()
                .Save(this);
        }

        /// <summary>
        /// Gets person by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static Person Get(int id)
        {
            return DI.Resolve<IRepositoryFactory>()
                    .GetPersonRepository()
                    .Get(id);
        }
    }
}