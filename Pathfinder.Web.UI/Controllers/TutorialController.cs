using System.Web.Mvc;

namespace Pathfinder.Web.UI.Controllers
{
    public class TutorialController : ControllerBase
    {
        //
        // GET: /Tutorial/

        public ActionResult Index()
        {
            return View();
        }
    }
}