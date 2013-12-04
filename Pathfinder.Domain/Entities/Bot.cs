using System;

using Pathfinder.Bot;

namespace Pathfinder.Domain.Entities
{
    public class Bot : DomainTransferableEntity
    {
        /// <summary>
        /// Alias (user friendly name)
        /// </summary>
        public string Alias { get; set; }

        /// <summary>
        /// Description
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Filename
        /// </summary>
        public string Filename { get; set; }

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