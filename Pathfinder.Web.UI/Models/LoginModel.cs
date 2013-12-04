using System.ComponentModel.DataAnnotations;

namespace Pathfinder.Web.UI.Models
{
    public class LoginModel : ModelBase
    {
        /// <summary>
        /// Username of person
        /// </summary>
        [Required]
        public string Username { get; set; }

        /// <summary>
        /// Password hash
        /// </summary>
        [Required]
        public string Password { get; set; }
    }
}