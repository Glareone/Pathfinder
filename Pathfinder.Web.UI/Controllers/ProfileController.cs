using System;
using System.Web;
using System.Web.Mvc;

using Pathfinder.Bot.Validation;
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

            var user = LoginManager.Instance.Current();
            return View(new ProfileModel(user)
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

                    byte[] botContent = new byte[file.InputStream.Length];
                    file.InputStream.Read(botContent, 0, botContent.Length);

                    using (var botAssemblyValidator = new AssemblyValidator())
                    {
                        try
                        {
                            botAssemblyValidator.Validate(botContent);

                            var bot = new Domain.Entities.Bot(person)
                            {
                                Alias = model.UploadBot.BotAlias,
                                Description = model.UploadBot.BotDescription,
                                Filename = file.FileName,
                                Content = botContent
                            };

                            bot.Save();
                        }
                        catch (Exception ex)
                        {
                            Error(ex.Message);
                        }
                    }
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

        [HttpPost]
        public ActionResult DeleteBot(BotModel botModel)
        {
            DomainContext.Instance.RepositoryFactory
                .GetBotRepository()
                .Delete(botModel.BotId);

            return RedirectToAction("Index");
        }
    }
}
