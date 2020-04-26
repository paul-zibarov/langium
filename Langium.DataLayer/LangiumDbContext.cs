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
            Database.EnsureDeleted();
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(DbConnectionProvider.GetConnectionString());
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserModel>(UserConfigure);
            modelBuilder.Entity<ProfileModel>(ProfileConfigure);
            modelBuilder.Entity<StatsModel>(StatsConfigure);
        }

        private void UserConfigure(EntityTypeBuilder<UserModel> builder)
        {
            builder.HasIndex(u => u.Email).IsUnique(); //email unique constraint

            builder.HasOne(u => u.Profile).WithOne(p => p.User).HasForeignKey<ProfileModel>(p => p.UserId); //fk UserProfile

            builder.Property(u => u.Email).IsRequired(); //login required constraint
            builder.Property(u => u.Password).IsRequired(); //password required constraint

            builder.Property(u => u.Email).HasMaxLength(30); //login size constraint
            builder.Property(u => u.Password).HasMaxLength(30); //password size constraint

            builder.Property(u => u.IsActivated).HasDefaultValue(false); //default value is activated
            builder.Property(u => u.RegistrationDate).HasDefaultValueSql("now()").ValueGeneratedOnAdd(); //default value registration date
        }

        private void ProfileConfigure(EntityTypeBuilder<ProfileModel> builder)
        {
            builder.Property(p => p.Name).HasMaxLength(30); //name size constraint

            builder.HasOne(p => p.Stats).WithOne(s => s.Profile).HasForeignKey<StatsModel>(p => p.UserId); //fk Stats
            builder.HasMany(p => p.Categories).WithOne(s => s.Profile).HasForeignKey(c => c.ProfileId); //fk Categories

            builder.Property(p => p.Age).HasDefaultValue(18); //default value age
        }

        private void StatsConfigure(EntityTypeBuilder<StatsModel> builder)
        {
            builder.Property(s => s.TotalAnswers).HasDefaultValue(0); //total answers default value
            builder.Property(s => s.RightAnswers).HasDefaultValue(0); //right answers default value
        }

        public DbSet<UserModel> Users { get; set; }

        public DbSet<ProfileModel> UserProfiles { get; set; }

        public DbSet<StatsModel> Stats { get; set; }
    }
}
