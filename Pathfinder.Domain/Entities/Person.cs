using System;
using System.Collections.Generic;

namespace Pathfinder.Domain.Entities
{
    [Serializable]
    public class Person : DomainEntity
    {
        /// <summary>
        /// Initializes a new instance of <see cref="Person"/> class
        /// </summary>
        public Person()
        {
            Bots = new List<Bot>();
        }

        /// <summary>
        /// Username of person
        /// </summary>
        public string Username { get; set; }

        /// <summary>
        /// First name
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Last name
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// Password hash
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// Gets display name
        /// </summary>
        public string DisplayName
        {
            get
            {
                if (!string.IsNullOrEmpty(LastName) || !string.IsNullOrEmpty(FirstName))
                {
                    return string.Format("{0} {1}", FirstName, LastName);
                }

                return Username;
            }
        }

        /// <summary>
        /// Bots collection
        /// </summary>
        public virtual List<Bot> Bots { get; set; }

        /// <summary>
        /// Saves instance
        /// </summary>
        public void Save()
        {
            DomainContext.Instance.RepositoryFactory
                .GetPersonRepository()
                .Save(this);
        }
    }
}