using EfCoreMigrationDemo.Data.Entities;
using EfCoreMigrationDemo.Data.EntityConfig;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.IO;

namespace EfCoreMigrationDemo.Data
{
    public class MyDbContext : DbContext
    {
        //default constructor - gets called by migration script execution
        public MyDbContext()
        {

        }

        //constructor to be called from the project that consumes the DbContext.  With the dbContextOptions, the invoking project can pass in configuration such as connection string.
        public MyDbContext(DbContextOptions dbContextOptions) : base (dbContextOptions)
        {

        }

        //the entity collections
        public DbSet<User> Users { get; set; }


        //invoke configuration of entities
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserConfig());
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var config = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("dbSettings.json")
                    .Build();

                var connectionString = config.GetConnectionString("MyDb");
                optionsBuilder.UseSqlServer(connectionString);
            }
        }

    }
}
