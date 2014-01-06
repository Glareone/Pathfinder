using System.Web.Mvc;

using Pathfinder.Security;
using Pathfinder.Web.Core;
using Pathfinder.Web.UI.Extensions;
using Pathfinder.Web.UI.Models;

namespace Pathfinder.Web.UI.Controllers
{
    public class LoginController : ControllerBase
    {
        public const string PASSWORD_SALT = "kldsai9n2o1emklcmalkmsd0a9DAS(*D)(SA^&*y832928109d8s9a08d9a8YSNDajjoidjsaoihh1h1232DUS)A(DJAasdoa";

        [HttpPost]
        public ActionResult SignIn(LoginModel loginModel)
        {
            if (ModelState.IsValid)
            {
                LoginManagerError error;
                if (!LoginManager.Instance.TryToSingIn(loginModel.Username, HashPassword(loginModel.Password), out error))
                {
                    Error(error.DisplayName());
                }
            }
            else
            {
                Error("Invalid Username / Password.");
            }

            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public ActionResult SingUp(LoginModel loginModel)
        {
            if (ModelState.IsValid)
            {
                LoginManagerError error;
                if (!LoginManager.Instance.TryToSingUp(loginModel.Username, HashPassword(loginModel.Password), out error))
                {
                    Error(error.DisplayName());
                }
            }
            else
            {
                Error("Invalid Username / Password.");
            }

            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public ActionResult SingOut()
        {
            LoginManager.Instance.SignOut();

            return RedirectToAction("Index", "Home");
        }

        /// <summary>
        /// Hashes password
        /// </summary>
        /// <param name="password"></param>
        /// <returns></returns>
        protected string HashPassword(string password)
        {
            return new HashComputer().ComputeHash(password, PASSWORD_SALT);
        }
    }
}
