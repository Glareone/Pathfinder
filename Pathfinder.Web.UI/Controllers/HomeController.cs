﻿using System.Web.Mvc;

namespace Pathfinder.Web.UI.Controllers
{
    public class HomeController : ControllerBase
    {
        //
        // GET: /Home/

        public ActionResult Index()
        {
            return View();
        }
    }
}