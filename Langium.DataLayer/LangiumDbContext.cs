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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //unique_constraint
            modelBuilder
                .Entity<UserModel>()
                .HasIndex(u => u.Login)
                .IsUnique();

            modelBuilder
                .Entity<UserProfileModel>()
                .HasIndex(u => u.Email)
                .IsUnique();

            //FK_constraint
            modelBuilder
                .Entity<UserModel>()
                .HasOne(u => u.Profile)
                .WithOne(p => p.User)
                .HasForeignKey<UserProfileModel>(p => p.UserId);

            modelBuilder
                .Entity<UserModel>()
                .HasOne(u => u.Stats)
                .WithOne(s => s.User)
                .HasForeignKey<StatsModel>(s => s.UserId);

            //require_constraint
            modelBuilder
                .Entity<UserModel>()
                .Property(u => u.Login)
                .IsRequired();

            modelBuilder
                .Entity<UserModel>()
                .Property(u => u.Password)
                .IsRequired();

            //size_constraint
            modelBuilder
                .Entity<UserProfileModel>()
                .Property(p => p.Name)
                .HasMaxLength(30);

            modelBuilder
                .Entity<UserProfileModel>()
                .Property(p => p.Email)
                .HasMaxLength(50);

            modelBuilder
                .Entity<UserModel>()
                .Property(u => u.Login)
                .HasMaxLength(30);

            modelBuilder
                .Entity<UserModel>()
                .Property(u => u.Password)
                .HasMaxLength(30);

            //default_values
            modelBuilder
                .Entity<StatsModel>()
                .Property(s => s.TotalAnswers)
                .HasDefaultValue(0);

            modelBuilder
                .Entity<StatsModel>()
                .Property(s => s.RightAnswers)
                .HasDefaultValue(0);

            modelBuilder
                .Entity<UserProfileModel>()
                .Property(p => p.RegistrationDate)
                .HasDefaultValueSql("now()")
                .ValueGeneratedOnAdd();
        }

        public DbSet<UserModel> Users { get; set; }

        public DbSet<UserProfileModel> UserProfiles { get; set; }

        public DbSet<StatsModel> Stats { get; set; }
    }
}
