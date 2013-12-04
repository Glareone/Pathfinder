using System.Web.Mvc;

using Pathfinder.Domain;
using Pathfinder.Web.Core;
using Pathfinder.Web.UI.Models;

namespace Pathfinder.Web.UI.Controllers
{
    public class ProfileController : ControllerBase
    {
        public ActionResult Index()
        {
            if (!LoginManager.Instance.IsSingedIn())
            {
                return RedirectToAction("Index", "Home");
            }

            return View(new ProfileModel
            {
                Person = LoginManager.Instance.Current(),
                Navigation = Navigation.Profile
            });
        }

        [HttpPost]
        public ActionResult EditPersonalInformation(ProfileModel model)
        {
            if (ModelState.IsValid)
            {
                var person = DomainContext.Instance.RepositoryFactory
                    .GetPersonRepository()
                    .Find(model.Person.Id);

                person.FirstName = model.Person.FirstName;
                person.LastName = model.Person.LastName;

                person.Save();
            }

            return RedirectToAction("Index");
        }
    }
}
