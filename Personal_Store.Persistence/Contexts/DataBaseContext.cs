using Microsoft.EntityFrameworkCore;
using Personal_Store.Application.Interfaces.Contexts;
using Personal_Store.Common.Roles;
using Personal_Store.Domain.Entities.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Personal_Store.Persistence.Contexts
{
    public class DataBaseContext : DbContext, IDataBaseContext
    {
        public DataBaseContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<UserInRole> UserInRoles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Role>().HasData(new Role { ID = 1, Name = nameof(UserRoles.Admin) });
            modelBuilder.Entity<Role>().HasData(new Role { ID = 2, Name = nameof(UserRoles.Operator) });
            modelBuilder.Entity<Role>().HasData(new Role { ID = 3, Name = nameof(UserRoles.Customer) });

            // Create index field in data base
            modelBuilder.Entity<User>().HasIndex(x => x.Email).IsUnique();

            // Create query filters
            modelBuilder.Entity<User>().HasQueryFilter(x => !x.IsRemoved);
        }

    }
}
