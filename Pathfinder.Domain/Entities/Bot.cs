using System;

using Pathfinder.Bot;

namespace Pathfinder.Domain.Entities
{
    public class Bot : DomainEntity
    {
        /// <summary>
        /// Loads bot
        /// </summary>
        /// <returns></returns>
        public IBot LoadBot()
        {
            throw new NotImplementedException("Bot is missing.");
        }
    }
}