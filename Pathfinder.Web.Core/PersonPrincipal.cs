using System.Security.Principal;

using Pathfinder.Domain.Entities;

namespace Pathfinder.Web.Core
{
    public class PersonPrincipal : IPrincipal
    {
        /// <summary>
        /// Initializes a new instance of <see cref="PersonPrincipal"/> class
        /// </summary>
        public PersonPrincipal(Person person)
        {
            Identity = new PersonIdentity(person);
        }

        /// <summary>
        /// Gets the identity of the current principal.
        /// </summary>
        /// <returns>
        /// The <see cref="T:System.Security.Principal.IIdentity"/> object associated with the current principal.
        /// </returns>
        public IIdentity Identity { get; private set; }

        /// <summary>
        /// Determines whether the current principal belongs to the specified role.
        /// </summary>
        /// <returns>
        /// true if the current principal is a member of the specified role; otherwise, false.
        /// </returns>
        /// <param name="role">The name of the role for which to check membership. </param>
        public bool IsInRole(string role)
        {
            return true;
        }
    }
}