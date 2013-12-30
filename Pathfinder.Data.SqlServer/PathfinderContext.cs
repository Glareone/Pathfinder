using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;

using Pathfinder.Domain.Entities;

namespace Pathfinder.Data.SqlServer
{
    public class PathfinderContext : DbContext
    {
        public DbSet<Person> Persons { get; set; }
    }
}
