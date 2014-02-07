using System.Web;
using System.Web.Mvc;

using Pathfinder.Dependency;
using Pathfinder.Domain;
using Pathfinder.Domain.Entities;
using Pathfinder.Engine;
using Pathfinder.Web.UI.Models;

namespace Pathfinder.Web.UI.Controllers
{
    public class MapController : ControllerBase
    {
        //
        // GET: /Map/

        public ActionResult Index()
        {
            new GameEngine().PlayGame(new GameEngineInvokerParameters(), new GameEngineParameters());
            var maps = DI.Resolve<IRepositoryFactory>()
                .GetMapRepository()
                .GetAll();

            return View(new MapsModel(maps)
            {
                Navigation = Navigation.Map
            });
        }

        [HttpPost]
        public ActionResult UploadMap(MapsModel model, HttpPostedFileBase image, HttpPostedFileBase content)
        {
            if (!string.IsNullOrEmpty(model.UploadMap.Name))
            {
                string error;
                if (ValidateImage(image, out error) &&
                    ValidateContent(content, out error))
                {
                    byte[] imageContent = new byte[image.InputStream.Length];
                    image.InputStream.Read(imageContent, 0, imageContent.Length);

                    byte[] contentContent = new byte[content.InputStream.Length];
                    content.InputStream.Read(contentContent, 0, contentContent.Length);

                    var map = new Map(model.UploadMap.Name, imageContent, contentContent);
                    map.Save();
                }
                else
                {
                    Error(error);
                }
            }
            else
            {
                Error("Bot alias is empty.");
            }

            return RedirectToAction("Index");
        }

        /// <summary>
        /// Validates image file
        /// </summary>
        /// <param name="image"></param>
        /// <param name="error"></param>
        /// <returns></returns>
        protected bool ValidateImage(HttpPostedFileBase image, out string error)
        {
            error = null;
            if (image != null)
            {
                if (!image.FileName.EndsWith(".png"))
                {
                    error = "'Png' image is expected.";

                    return false;
                }
            }
            else
            {
                error = "Image file is missing.";

                return false;
            }

            return true;
        }

        /// <summary>
        /// Validates content file
        /// </summary>
        /// <param name="content"></param>
        /// <param name="error"></param>
        /// <returns></returns>
        protected bool ValidateContent(HttpPostedFileBase content, out string error)
        {
            error = null;
            if (content != null)
            {
                if (!content.FileName.EndsWith(".tmx"))
                {
                    error = "'Tmx' image is expected.";

                    return false;
                }
            }
            else
            {
                error = "Content file is missing.";

                return false;
            }

            return true;
        }


        [HttpPost]
        public ActionResult DeleteMap(MapModel mapModel)
        {
            DI.Resolve<IRepositoryFactory>()
                .GetMapRepository()
                .Delete(mapModel.MapId);

            return RedirectToAction("Index");
        }
    }
}
