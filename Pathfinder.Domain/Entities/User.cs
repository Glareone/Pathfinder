namespace Pathfinder.Domain.Entities
{
    public class User : DomainEntity
    {
        /// <summary>
        /// Initializes a new instance of <see cref="User"/> class
        /// </summary>
        public User()
        {
            Role = Role.User;
        }

        /// <summary>
        /// Username of person
        /// </summary>
        public string Username { get; set; }

        /// <summary>
        /// Password hash
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// Role
        /// </summary>
        public Role Role { get; set; }

        /// <summary>
        /// Checks if user is in role
        /// </summary>
        /// <param name="role"></param>
        /// <returns></returns>
        public bool IsInRole(Role role)
        {
            return Role.HasFlag(role);
        }

        /// <summary>
        /// Person identifier
        /// </summary>
        public int PersonId { get; set; }

        /// <summary>
        /// Person representation
        /// </summary>
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