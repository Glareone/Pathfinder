using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

using Pathfinder.Domain.Entities;

namespace Pathfinder.Web.UI.Data
{
    [Serializable]
    public class PersonStorage : ICloneable
    {
        /// <summary>
        /// Default internal instance
        /// </summary>
        private static readonly PersonStorage _default = new PersonStorage();

        /// <summary>
        /// Initializes a new instance of <see cref="PersonStorage"/> class
        /// </summary>
        public PersonStorage()
        {
            Persons = new List<Person>();
        }

        /// <summary>
        /// Default instance
        /// </summary>
        public static PersonStorage Default
        {
            get
            {
                return (PersonStorage)_default.Clone();
            }
        }

        /// <summary>
        /// Persons collection
        /// </summary>
        public List<Person> Persons { get; private set; }

        /// <summary>
        /// Deserializes from file
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        public static PersonStorage Deserialize(string filePath)
        {
            using (var fileStream = File.OpenRead(filePath))
            {
                return new XmlSerializer(typeof(PersonStorage)).Deserialize(fileStream) as PersonStorage;
            }
        }

        /// <summary>
        /// Serializes to file
        /// </summary>
        /// <param name="filePath"></param>
        public void Serialize(string filePath)
        {
            using (var stream = File.OpenWrite(filePath))
            {
                new XmlSerializer(GetType()).Serialize(stream, this);
            }
        }

        /// <summary>
        /// Creates a new object that is a copy of the current instance.
        /// </summary>
        /// <returns>
        /// A new object that is a copy of this instance.
        /// </returns>
        public object Clone()
        {
            return MemberwiseClone();
        }
    }
}