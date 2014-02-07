using System;

using Pathfinder.Bot;
using Pathfinder.Dependency;

namespace Pathfinder.Domain.Entities
{
    public class Bot : DomainEntity
    {
        /// <summary>
        /// Initializes a new instance of <see cref="Bot"/> class
        /// </summary>
        public Bot() {}

        /// <summary>
        /// Initializes a new instance of <see cref="Bot"/> class
        /// </summary>
        public Bot(Person person)
        {
            PersonId = person.Id;
        }

        /// <summary>
        /// Person identifier
        /// </summary>
        public int PersonId { get; set; }
        
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
        /// Content
        /// </summary>
        public byte[] Content { get; set; }

        /// <summary>
        /// Loads bot
        /// </summary>
        /// <returns></returns>
        public IBot LoadBot()
        {
            throw new NotImplementedException("Bot is missing.");
        }

        /// <summary>
        /// Saves instance
        /// </summary>
        public override void Save()
        {
            DI.Resolve<IRepositoryFactory>()
                .GetBotRepository()
                .Save(this);
        }
    }
}