using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web;

namespace Pathfinder.Web.UI.Models
{
    public class UploadMapModel
    {
        /// <summary>
        /// Map name
        /// </summary>
        [Required]
        public string Name { get; set; }

        /// <summary>
        /// Map description
        /// </summary>
        public string Description { get; set; }
    }
}