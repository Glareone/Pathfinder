using Pathfinder.Web.Core;

namespace Pathfinder.Web.UI.Extensions
{
    public static class LoginManagerErrorExtensions
    {
        /// <summary>
        /// Gets display name for <see cref="LoginManagerError"/> enum
        /// </summary>
        /// <param name="error"></param>
        /// <returns></returns>
        public static string DisplayName(this LoginManagerError error)
        {
            switch (error)
            {
                case LoginManagerError.InvalidUsernamePassword:
                    return "Invalid Username / Password.";

                case LoginManagerError.UsernameAlreadyExists:
                    return "This username already exists.";
            }

            return error.ToString();
        }
    }
}