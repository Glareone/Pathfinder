using System;
using System.ComponentModel.DataAnnotations;

namespace Pathfinder.Web.UI.Models
{
    [Serializable]
    public class UploadBotModel
    {
        /// <summary>
        /// Bot alias
        /// </summary>
        [Required]
        public string BotAlias { get; set; }

        /// <summary>
        /// Bot description
        /// </summary>
        public string BotDescription { get; set; }
    }
}