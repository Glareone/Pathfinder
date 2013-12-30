using System.Web;
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

            var person = LoginManager.Instance.Current();
            return View(new ProfileModel(person)
                {
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
                    .Get(model.PersonId);

                person.FirstName = model.FirstName;
                person.LastName = model.LastName;

                person.Save();
            }

            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult UploadBot(ProfileModel model, HttpPostedFileBase file)
        {
            if (!string.IsNullOrEmpty(model.UploadBot.BotAlias))
            {
                if (file != null)
                {
                    var person = DomainContext.Instance.RepositoryFactory
                        .GetPersonRepository()
                        .Get(model.PersonId);

                    var bot = new BotManager().SaveBot(person.Id, model.UploadBot.BotAlias, model.UploadBot.BotDescription, file.InputStream);

                    person.Bots.Add(bot);
                    person.Save();
                }
                else
                {
                    Error("Bot file is not provided.");
                }
            }
            else
            {
                Error("Bot alias is empty.");
            }

            return RedirectToAction("Index");
        }
    }
}
