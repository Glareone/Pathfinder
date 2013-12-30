using System.Security.Principal;

namespace Pathfinder.Web.Core
{
    public class PersonIdentity : IIdentity
    {
        /// <summary>
        /// Initializes a new instance of <see cref="PersonIdentity"/> class
        /// </summary>
        /// <param name="personId"></param>
        public PersonIdentity(int personId)
        {
            PersonId = personId;
        }

        /// <summary>
        /// Gets person identifier
        /// </summary>
        public int PersonId
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets the name of the current user.
        /// </summary>
        /// <returns>
        /// The name of the user on whose behalf the code is running.
        /// </returns>
        public string Name
        {
            get
            {
                return string.Format("PersonId:{0}", PersonId);
            }
        }

        /// <summary>
        /// Gets the type of authentication used.
        /// </summary>
        /// <returns>
        /// The type of authentication used to identify the user.
        /// </returns>
        public string AuthenticationType { get; private set; }

        /// <summary>
        /// Gets a value that indicates whether the user has been authenticated.
        /// </summary>
        /// <returns>
        /// true if the user was authenticated; otherwise, false.
        /// </returns>
        public bool IsAuthenticated
        {
            get
            {
                return true;
            }
        }
    }
}