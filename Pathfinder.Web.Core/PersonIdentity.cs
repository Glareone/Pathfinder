﻿using System.Security.Principal;

using Pathfinder.Domain.Entities;

namespace Pathfinder.Web.Core
{
    public class PersonIdentity : IIdentity
    {
        /// <summary>
        /// Initializes a new instance of <see cref="PersonIdentity"/> class
        /// </summary>
        /// <param name="person"></param>
        public PersonIdentity(Person person)
        {
            Person = person;
        }

        /// <summary>
        /// Gets person
        /// </summary>
        public Person Person
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
                return Person.DisplayName;
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