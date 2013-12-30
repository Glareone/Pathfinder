using System;
using System.IO;

using Pathfinder.Bot;
using Pathfinder.Data;
using Pathfinder.Domain.Entities;

namespace Pathfinder.Web.Core
{
    public class BotManager
    {
        /// <summary>
        /// Saves bot
        /// </summary>
        /// <param name="personId"></param>
        /// <param name="alias"></param>
        /// <param name="description"></param>
        /// <param name="stream"></param>
        /// <returns></returns>
        public Domain.Entities.Bot SaveBot(int personId, string alias, string description, Stream stream)
        {
            var botFilename = Guid.NewGuid().ToString().Replace("-", string.Empty);

            var botPath = string.Format("Repository\\Person\\{0}\\bots/{1}", personId, botFilename);

            DataContext.Instance.FileStorage.Save(botPath, stream);

            return new Domain.Entities.Bot
                          {
                              Alias = alias,
                              Description = description,
                              Filename = botFilename
                          };
        }

        /// <summary>
        /// Loads bot implementation
        /// </summary>
        /// <param name="person"></param>
        /// <param name="bot"></param>
        /// <returns></returns>
        public IBot LoadBot(Person person, Domain.Entities.Bot bot)
        {
            throw new NotImplementedException("Load bot is missing.");
        }
    }
}