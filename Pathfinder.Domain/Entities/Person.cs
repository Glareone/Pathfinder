using System;

namespace Pathfinder.Domain.Entities
{
    [Serializable]
    public class Person : EntityBase<Guid>
    {
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
        /// Saves instance
        /// </summary>
        public void Save()
        {
            DomainContext.Instance.RepositoryFactory
                .GetPersonRepository()
                .Save(this);
        }

        /// <summary>
        /// Checks if persisted
        /// </summary>
        /// <returns></returns>
        public override bool IsPersisted()
        {
            return Id != Guid.Empty;
        }
    }
}