namespace Pathfinder.Web.UI.Models
{
    public class BotModel
    {
        /// <summary>
        /// Initializes a new instance of <see cref="BotModel"/> class
        /// </summary>
        public BotModel()
        {
        }

        /// <summary>
        /// Initializes a new instance of <see cref="BotModel"/> class
        /// </summary>
        public BotModel(Domain.Entities.Bot bot)
        {
            BotId = bot.Id;
            Alias = bot.Alias;
            Description = bot.Description;
        }

        /// <summary>
        /// Bot identifier
        /// </summary>
        public int BotId { get; set; }

        /// <summary>
        /// Alias
        /// </summary>
        public string Alias { get; set; }

        /// <summary>
        /// Description
        /// </summary>
        public string Description { get; set; }
    }
}