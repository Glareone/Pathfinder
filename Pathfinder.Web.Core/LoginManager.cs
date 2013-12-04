using System;
using System.Web;
using System.Web.Security;

using Pathfinder.Domain;
using Pathfinder.Domain.Entities;

namespace Pathfinder.Web.Core
{
    public sealed class LoginManager
    {
        public static readonly LoginManager Instance = new LoginManager();

        /// <summary>
        /// Initializes a new instance of <see cref="LoginManager"/> class
        /// </summary>
        private LoginManager()
        {
        }

        /// <summary>
        /// Tries to sing in
        /// </summary>
        /// <param name="password"></param>
        /// <param name="error"></param>
        /// <param name="username"></param>
        /// <returns></returns>
        public bool TryToSingIn(string username, string password, out string error)
        {
            error = null;

            var person = DomainContext.Instance.RepositoryFactory.GetPersonRepository()
                .Find(username, password);
            if (person == null)
            {
                error = "Invalid Username / Password.";

                return false;
            }

            Authenticate(person);

            return true;
        }

        /// <summary>
        /// Tries to sign in
        /// </summary>
        /// <param name="password"></param>
        /// <param name="error"></param>
        /// <param name="username"></param>
        /// <returns></returns>
        public bool TryToSingUp(string username, string password, out string error)
        {
            error = null;

            var person = DomainContext.Instance.RepositoryFactory.GetPersonRepository()
                .Find(username, password);
            if (person != null)
            {
                error = "This username already exists.";

                return false;
            }

            person = new Person
                             {
                                 Username = username,
                                 Password = password
                             };
            person.Save();

            Authenticate(person);

            return true;
        }

        /// <summary>
        /// Signs out
        /// </summary>
        public void SignOut()
        {
            FormsAuthentication.SignOut();
        }

        /// <summary>
        /// Checks if current user is signed in
        /// </summary>
        /// <returns></returns>
        public bool IsSingedIn()
        {
            return Current() != null;
        }

        /// <summary>
        /// Gets current signed in person
        /// </summary>
        /// <returns></returns>
        public Person Current()
        {
            var currentPrincipal = HttpContext.Current.User as PersonPrincipal;
            if (currentPrincipal == null)
            {
                var authCookie = HttpContext.Current.Request.Cookies[FormsAuthentication.FormsCookieName];

                if (authCookie != null)
                {
                    var ticket = FormsAuthentication.Decrypt(authCookie.Value);
                    if (ticket != null && !ticket.Expired)
                    {
                        var person = DomainContext.Instance.RepositoryFactory.GetPersonRepository()
                            .Find(Guid.Parse(ticket.Name));
                        if (person != null)
                        {
                            HttpContext.Current.User = currentPrincipal = new PersonPrincipal(person.Id);
                        }
                    }
                }
            }

            if (currentPrincipal != null)
            {
                return DomainContext.Instance.RepositoryFactory.GetPersonRepository()
                    .Find(((PersonIdentity)currentPrincipal.Identity).PersonId);
            }

            return null;
        }

        /// <summary>
        /// Authenticate the person
        /// </summary>
        /// <param name="person"></param>
        private void Authenticate(Person person)
        {
            FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(
                1,
                person.Id.ToString(),
                DateTime.Now,
                DateTime.Now.AddDays(14),
                true,
                string.Empty,
                FormsAuthentication.FormsCookiePath);

            string encTicket = FormsAuthentication.Encrypt(ticket);

            HttpContext.Current.Response.Cookies.Add(new HttpCookie(FormsAuthentication.FormsCookieName, encTicket));
        }
    }
}