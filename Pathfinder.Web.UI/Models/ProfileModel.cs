using System;

using Pathfinder.Domain.Entities;

namespace Pathfinder.Web.UI.Models
{
    [Serializable]
    public class ProfileModel : ModelBase
    {
        /// <summary>
        /// Current person
        /// </summary>
         public Person Person { get; set; }
    }
}