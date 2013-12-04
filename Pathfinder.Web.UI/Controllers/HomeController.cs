using System.Web.Mvc;

using Pathfinder.Web.UI.Models;

namespace Pathfinder.Web.UI.Controllers
{
    public class HomeController : ControllerBase
    {
        //
        // GET: /Home/

        public ActionResult Index()
        {
            return View(new ModelBase
                            {
                                Navigation = Navigation.Home
                            });
        }
    }
}