﻿using System;
using System.Security.Principal;

namespace Pathfinder.Web.Core
{
    public class UserPrincipal : IPrincipal
    {
        /// <summary>
        /// Initializes a new instance of <see cref="UserPrincipal"/> class
        /// </summary>
        public UserPrincipal(int userId)
        {
            Identity = new UserIdentity(userId);
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