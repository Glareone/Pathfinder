using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Pathfinder.Web.UI.Models;

namespace Pathfinder.Web.UI.Controllers
{
    public class FileStorageController : ControllerBase
    {
        //
        // GET: /Storage/

        public FileResult StarterPackage(StarterPackageModel starterPackageModel)
        {
            switch (starterPackageModel.Type)
            {
                case StarterPackageType.DotNET:
                    return new FilePathResult(HttpContext.Server.MapPath("~/App_Data/StarterPackages/Pathfinder.Bot.zip"), "application/zip");
            }

            throw new InvalidOperationException("Unable to determine file.");
        }

    }
}
