using Pathfinder.Domain.Entities;

namespace Pathfinder.Web.UI.Models
{
    public class MapModel
    {
        /// <summary>
        /// Initializes a new instance of <see cref="MapModel"/> class
        /// </summary>
        public MapModel(Map map)
        {
            MapId = map.Id;
            Name = map.Name;
        }

        /// <summary>
        /// Map identifier
        /// </summary>
        public int MapId { get; set; }

        /// <summary>
        /// Name
        /// </summary>
        public string Name { get; set; }
    }
}