using System;

namespace Pathfinder.Domain.Entities
{
    [Serializable]
    public abstract class DomainEntity : EntityBase<int>
    {
        /// <summary>
        /// Checks if persisted
        /// </summary>
        /// <returns></returns>
        public override bool IsPersisted()
        {
            return Id > 0;
        }
    }
}