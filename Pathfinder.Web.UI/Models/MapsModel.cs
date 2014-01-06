using System.Collections.Generic;

using Pathfinder.Domain.Entities;

namespace Pathfinder.Web.UI.Models
{
    public class MapsModel : ModelBase
    {
        /// <summary>
        /// Initializes a new instance of <see cref="MapsModel"/> class
        /// </summary>
        public MapsModel()
        {
            Maps = new List<MapModel>();
        }

        /// <summary>
        /// Initializes a new instance of <see cref="MapsModel"/> class
        /// </summary>
        public MapsModel(IEnumerable<Map> maps) : this()
        {
            foreach (var map in maps)
            {
                Maps.Add(new MapModel(map));
            }
        }

        /// <summary>
        /// Maps collection
        /// </summary>
        public List<MapModel> Maps { get; set; }

        /// <summary>
        /// Upload map model
        /// </summary>
        public UploadMapModel UploadMap { get; set; }
    }
}