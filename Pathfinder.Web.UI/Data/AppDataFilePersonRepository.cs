using System;
using System.Collections.Generic;

using Pathfinder.Data;
using Pathfinder.Domain.Entities;
using Pathfinder.Domain.Repository;

namespace Pathfinder.Web.UI.Data
{
    public class AppDataFilePersonRepository : IPersonRepository
    {
        private const string STORAGE_PATH = "PersonStorage/data.xml";

        private PersonStorage _storage;

        /// <summary>
        /// Person storage
        /// </summary>
        protected PersonStorage Storage
        {
            get
            {
                lock (typeof(AppDataFilePersonRepository))
                {
                    if (_storage == null)
                    {
                        var storageFile = DataContext.Instance.FileStorage.Load(STORAGE_PATH);

                        if (!storageFile.Exists)
                        {
                            PersonStorage.Default.Serialize(storageFile.FullName);
                        }

                        _storage = PersonStorage.Deserialize(storageFile.FullName);
                    }
                }
                
                return _storage;
            }
        }

        /// <summary>
        /// Get all
        /// </summary>
        /// <returns></returns>
        public List<Person> GetAll()
        {
            return Storage.Persons;
        }

        /// <summary>
        /// Finds person username and password
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public Person Find(string username, string password)
        {
            return Storage.Persons.Find(x => string.Equals(x.Username, username, StringComparison.CurrentCultureIgnoreCase) && string.Equals(x.Password, password));
        }

        /// <summary>
        /// Finds person username
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        public Person Find(string username)
        {
            return Storage.Persons.Find(x => string.Equals(x.Username, username));
        }

        /// <summary>
        /// Finds person by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Person Find(Guid id)
        {
            return Storage.Persons.Find(x => x.Id == id);
        }

        /// <summary>
        /// Saves person
        /// </summary>
        /// <param name="person"></param>
        public void Save(Person person)
        {
            if (person.IsPersisted())
            {
                Storage.Persons.RemoveAll(x => x.Id == person.Id);

                Storage.Persons.Add(person);
            }
            else
            {
                person.Id = Guid.NewGuid();

                Storage.Persons.Add(person);
            }

            PersistStorage();
        }


        /// <summary>
        /// Persists storage
        /// </summary>
        protected void PersistStorage()
        {
            var storageFile = DataContext.Instance.FileStorage.Load(STORAGE_PATH);
            Storage.Serialize(storageFile.FullName);
        }
    }
}