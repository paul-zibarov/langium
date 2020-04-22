using Langium.DataLayer.DbModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Langium.DataLayer
{
    public class LangiumDbContext : DbContext
    {
        public LangiumDbContext()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(DbConnectionProvider.GetConnectionString());
        }

        public DbSet<UserModel> Users { get; set; }

        public DbSet<UserProfileModel> UserProfiles { get; set; }

        public DbSet<StatsModel> Stats { get; set; }
    }
}
