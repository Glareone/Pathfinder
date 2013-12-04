using System;

namespace Pathfinder.Domain.Entities
{
    public class DomainTransferableEntity : EntityBase<Guid>
    {
        /// <summary>
        /// Checks if persisted
        /// </summary>
        /// <returns></returns>
        public override bool IsPersisted()
        {
            return Id != Guid.Empty;
        }
    }
}