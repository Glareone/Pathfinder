using System.Web.Mvc;

using Pathfinder.Web.UI.Models;

namespace Pathfinder.Web.UI.Controllers
{
    public class TutorialController : ControllerBase
    {
        //
        // GET: /Tutorial/

        public ActionResult Index()
        {
            return View(new ModelBase
            {
                Navigation = Navigation.Tutorial
            });
        }
    }
}