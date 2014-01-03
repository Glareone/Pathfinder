using System;
using System.Collections.Generic;

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
                return _bots ?? (_bots = DomainContext.Instance.RepositoryFactory
                    .GetBotRepository()
                    .GetBots(this));
            }
        }

        /// <summary>
        /// Saves instance
        /// </summary>
        public override void Save()
        {
            DomainContext.Instance.RepositoryFactory
                .GetPersonRepository()
                .Save(this);
        }
    }
}