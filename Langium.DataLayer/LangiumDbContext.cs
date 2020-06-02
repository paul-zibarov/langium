using Langium.DataLayer.DbModels;
using Langium.Domain;
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
            modelBuilder.Entity<ProfileModel>(ProfileConfigure);
            modelBuilder.Entity<StatsModel>(StatsConfigure);
            modelBuilder.Entity<WordModel>(WordConfigure);
            modelBuilder.Entity<CategoryModel>(CategoryConfigure);
            modelBuilder.Entity<LexemeModel>(LexemeConfigure);
            modelBuilder.Entity<TranscriptionModel>(TranscriptionConfigure);
            modelBuilder.Entity<TranslationModel>(TranslationConfigure);
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
            builder.Property(u => u.ActivationCode).HasDefaultValue(ActivationHelper.GetActivationCode()); //default value activation code
            builder.Property(u => u.RegistrationDate).HasDefaultValueSql("now()").ValueGeneratedOnAdd(); //default value registration date
        }

        private void ProfileConfigure(EntityTypeBuilder<ProfileModel> builder)
        {
            builder.Property(p => p.Name).HasMaxLength(30); //name size constraint

            builder.HasOne(p => p.Stats).WithOne(s => s.Profile).HasForeignKey<StatsModel>(p => p.ProfileId); //fk Stats
            builder.HasMany(p => p.Categories).WithOne(s => s.Profile).HasForeignKey(c => c.ProfileId); //fk Categories

            builder.Property(p => p.Age).HasDefaultValue(18); //default value age
        }

        private void StatsConfigure(EntityTypeBuilder<StatsModel> builder)
        {
            builder.Property(s => s.TotalAnswers).HasDefaultValue(0); //total answers default value
            builder.Property(s => s.RightAnswers).HasDefaultValue(0); //right answers default value
        }

        private void WordConfigure(EntityTypeBuilder<WordModel> builder)
        {
            builder.HasOne(w => w.Lexeme).WithOne(l => l.Word).HasForeignKey<LexemeModel>(l => l.WordId); //fk Lexeme
            builder.HasOne(w => w.Transcription).WithOne(t => t.Word).HasForeignKey<TranscriptionModel>(t => t.WordId); //fk Transcription
            builder.HasMany(w => w.Translations).WithOne(t => t.Word).HasForeignKey(t => t.WordId); //fk Translations
        }

        private void CategoryConfigure(EntityTypeBuilder<CategoryModel> builder)
        {
            builder.Property(c => c.Name).IsRequired(); //category required constraint
            builder.Property(c => c.Name).HasMaxLength(30); //category size constraint
        }

        private void LexemeConfigure(EntityTypeBuilder<LexemeModel> builder)
        {
            builder.Property(l => l.Lexeme).IsRequired(); //lexeme required constraint
            builder.Property(l => l.Lexeme).HasMaxLength(30); //lexeme size constraint
        }

        private void TranslationConfigure(EntityTypeBuilder<TranslationModel> builder)
        {
            builder.Property(t => t.Translation).IsRequired(); //translation required constraint
            builder.Property(t => t.Translation).HasMaxLength(30); //translation size constraint
        }

        private void TranscriptionConfigure(EntityTypeBuilder<TranscriptionModel> builder)
        {
            builder.Property(t => t.Transcription).IsRequired(); //transcription required constraint
            builder.Property(t => t.Transcription).HasMaxLength(30); //transcription size constraint
        }

        public DbSet<UserModel> Users { get; set; }

        public DbSet<ProfileModel> UserProfiles { get; set; }

        public DbSet<StatsModel> Stats { get; set; }

        public DbSet<WordModel> Words { get; set; }

        public DbSet<CategoryModel> Categories { get; set; }

        public DbSet<LexemeModel> Lexemes { get; set; }

        public DbSet<TranscriptionModel> Transcriptions { get; set; }

        public DbSet<TranslationModel> Translations { get; set; }
    }
}
