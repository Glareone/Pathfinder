﻿using System;
using System.Web;
using System.Web.Security;

using Pathfinder.Dependency;
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
        public bool TryToSingIn(string username, string password, out LoginManagerError error)
        {
            error = LoginManagerError.None;

            var user = DI.Resolve<IRepositoryFactory>().GetUserRepository()
                .Find(username, password);
            if (user != null)
            {
                Authenticate(user);

                return true;
            }

            error = LoginManagerError.InvalidUsernamePassword;

            return false;
        }

        /// <summary>
        /// Tries to sign in
        /// </summary>
        /// <param name="password"></param>
        /// <param name="error"></param>
        /// <param name="username"></param>
        /// <returns></returns>
        public bool TryToSingUp(string username, string password, out LoginManagerError error)
        {
            error = LoginManagerError.None;

            var user = DI.Resolve<IRepositoryFactory>().GetUserRepository()
                .Find(username, password);
            if (user == null)
            {
                var person = new Person
                                 {
                                     LastName = username
                                 };
                person.Save();

                user = new User
                    {
                        Username = username,
                        Password = password,
                        PersonId = person.Id
                    };

                user.Save();

                Authenticate(user);

                return true;
            }

            error = LoginManagerError.UsernameAlreadyExists;

            return false;
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
            return CurrentUserId().HasValue;
        }

        /// <summary>
        /// Gets current signed in user
        /// </summary>
        /// <returns></returns>
        public User Current()
        {
            var currentUserId = CurrentUserId();
            if (currentUserId.HasValue)
            {
                return DI.Resolve<IRepositoryFactory>().GetUserRepository()
                    .Get(currentUserId.Value);
            }

            return null;
        }

        /// <summary>
        /// Gets current signed in user
        /// </summary>
        /// <returns></returns>
        private int? CurrentUserId()
        {
            var currentPrincipal = HttpContext.Current.User as UserPrincipal;
            if (currentPrincipal == null)
            {
                var authCookie = HttpContext.Current.Request.Cookies[FormsAuthentication.FormsCookieName];

                if (authCookie != null)
                {
                    var ticket = FormsAuthentication.Decrypt(authCookie.Value);
                    if (ticket != null && !ticket.Expired)
                    {
                        var person = DI.Resolve<IRepositoryFactory>().GetUserRepository()
                            .Get(int.Parse(ticket.Name));
                        if (person != null)
                        {
                            HttpContext.Current.User = currentPrincipal = new UserPrincipal(person.Id);
                        }
                    }
                }
            }

            if (currentPrincipal != null)
            {
                return ((UserIdentity)currentPrincipal.Identity).UserId;
            }

            return null;
        }

        /// <summary>
        /// Authenticate the user
        /// </summary>
        /// <param name="user"></param>
        private void Authenticate(User user)
        {
            FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(
                1,
                user.Id.ToString(),
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