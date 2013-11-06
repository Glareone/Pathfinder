using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Pathfinder.Domain;

namespace Pathfinder.Web.UI.Controllers
{
    public class ContentController : Controller
    {
        //
        // GET: /Content/

        public ActionResult Image(string path)
        {
            var content = DomainContext.Instance.RepositoryFactory.GetContentRepository().GetImage(path);
            return new FileContentResult(content, "image");
        }

    }
}
