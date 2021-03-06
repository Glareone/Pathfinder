﻿using System.Data.Entity;

using Pathfinder.Domain.Entities;

namespace Pathfinder.Data.SqlServer
{
    public class PathfinderContext : DbContext
    {
        /// <summary>
        /// Initializes a new instance of <see cref="PathfinderContext"/> class
        /// </summary>
        public PathfinderContext() : base("db")
        {
        }

        public DbSet<User> Users { get; set; }

        public DbSet<Person> Persons { get; set; }

        public DbSet<Bot> Bots { get; set; }

        public DbSet<Map> Maps { get; set; }
    }
}
