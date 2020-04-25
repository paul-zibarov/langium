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
            modelBuilder.Entity<UserModel>(UserConfigure);
            modelBuilder.Entity<UserProfileModel>(UserProfileConfigure);
            modelBuilder.Entity<StatsModel>(StatsConfigure);
        }

        private void UserConfigure(EntityTypeBuilder<UserModel> builder)
        {
            builder.HasIndex(u => u.Login).IsUnique(); //login unique constraint

            builder.HasOne(u => u.Profile).WithOne(p => p.User).HasForeignKey<UserProfileModel>(p => p.UserId); //fk UserProfile
            builder.HasOne(u => u.Stats).WithOne(s => s.User).HasForeignKey<StatsModel>(p => p.UserId); //fk Stats
            builder.HasMany(u => u.Categories).WithOne(s => s.User).HasForeignKey(c => c.UserId); //fk Categories

            builder.Property(u => u.Login).IsRequired(); //login required constraint
            builder.Property(u => u.Password).IsRequired(); //password required constraint

            builder.Property(u => u.Login).HasMaxLength(30); //login size constraint
            builder.Property(u => u.Password).HasMaxLength(30); //password size constraint
        }

        private void UserProfileConfigure(EntityTypeBuilder<UserProfileModel> builder)
        {
            builder.HasIndex(u => u.Email).IsUnique(); //email unique constraint

            builder.Property(p => p.Name).HasMaxLength(30); //name size constraint
            builder.Property(p => p.Email).HasMaxLength(50); //email size constraint

            builder.Property(p => p.RegistrationDate).HasDefaultValueSql("now()").ValueGeneratedOnAdd(); //default value registraation date
        }

        private void StatsConfigure(EntityTypeBuilder<StatsModel> builder)
        {
            builder.Property(s => s.TotalAnswers).HasDefaultValue(0); //total answers default value
            builder.Property(s => s.RightAnswers).HasDefaultValue(0);//right answers default value
        }

        public DbSet<UserModel> Users { get; set; }

        public DbSet<UserProfileModel> UserProfiles { get; set; }

        public DbSet<StatsModel> Stats { get; set; }
    }
}
