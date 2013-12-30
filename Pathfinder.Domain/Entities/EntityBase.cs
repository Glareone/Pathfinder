using System.ComponentModel.DataAnnotations;

namespace Pathfinder.Domain.Entities
{
    public abstract class EntityBase<TId>
    {
        [Key]
        public TId Id { get; set; }

        /// <summary>
        /// Checks if persisted
        /// </summary>
        /// <returns></returns>
        public abstract bool IsPersisted();
    }
}