using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using Pathfinder.Dependency;
using Pathfinder.Domain;

namespace Pathfinder.Web.UI.Controllers
{
    public class ContentController : Controller
    {
        //
        // GET: /Content/

        public ActionResult Image(string path)
        {
            var content = DI.Resolve<IRepositoryFactory>().GetContentRepository().GetImage(path);
            return new FileContentResult(content, "image");
        }

    }
}
