namespace Pathfinder.Domain.Entities
{
    public class User : DomainEntity
    {
        /// <summary>
        /// Username of person
        /// </summary>
        public string Username { get; set; }

        /// <summary>
        /// Password hash
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// Person identifier
        /// </summary>
        public int PersonId { get; set; }

        public Person Person
        {
            get
            {
                return DomainContext.Instance.RepositoryFactory
                   .GetPersonRepository()
                   .Get(PersonId);
            }
        }

        /// <summary>
        /// Saves instance
        /// </summary>
        public override void Save()
        {
            DomainContext.Instance.RepositoryFactory
               .GetUserRepository()
               .Save(this);
        }
    }
}