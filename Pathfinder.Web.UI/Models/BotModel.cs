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
            Alias = bot.Alias;
            Description = bot.Description;
        }

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