using System;
using System.Collections.Generic;

using Pathfinder.Domain.Entities;

namespace Pathfinder.Web.UI.Models
{
    [Serializable]
    public class ProfileModel : ModelBase
    {
        /// <summary>
        /// Initializes a new instance of <see cref="ProfileModel"/> class
        /// </summary>
        public ProfileModel()
        {
            Bots = new List<BotModel>();
        }

        /// <summary>
        /// Initializes a new instance of <see cref="ProfileModel"/> class
        /// </summary>
        public ProfileModel(User user) : this()
        {
            PersonId = user.Person.Id;
            Username = user.Username;
            FirstName = user.Person.FirstName;
            LastName = user.Person.LastName;

            foreach (var bot in user.Person.Bots)
            {
                Bots.Add(new BotModel(bot));
            }
        }

        /// <summary>
        /// Current user identifier
        /// </summary>
        public int PersonId { get; set; }

        /// <summary>
        /// Username
        /// </summary>
        public string Username { get; set; }

        /// <summary>
        /// First name
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Last name
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// Bots collection
        /// </summary>
        public List<BotModel> Bots { get; set; }

        /// <summary>
        /// Upload bot model
        /// </summary>
        public UploadBotModel UploadBot { get; set; }
    }
}