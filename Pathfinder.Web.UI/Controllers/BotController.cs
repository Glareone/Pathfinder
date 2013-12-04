using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using Pathfinder.Data;
using Pathfinder.Domain;

namespace Pathfinder.Web.UI.Controllers
{
    public class BotController : Controller
    {
        //
        // GET: /Bot/

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(HttpPostedFileBase file)
        {
            var s = DomainContext.Instance.RepositoryFactory.GetPersonRepository().GetAll();
            DataContext.Instance.FileStorage.Save("Repository\\Person\\1\\bots/v1.0", file.InputStream);
            return View();
        }
    }
}
