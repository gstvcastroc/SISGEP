using Microsoft.EntityFrameworkCore;
using SISGEP.Application.Data.Mappings;
using SISGEP.Application.Entities;

namespace SISGEP.Application.Data
{
    public class SISGEPContext : DbContext
    {
#pragma warning disable CS8618

        public DbSet<Person> Persons { get; set; }

        public DbSet<Address> Addresses { get; set; }

        public DbSet<Project> Projects { get; set; }

        public DbSet<Survey> Surveys { get; set; }

        public DbSet<FilledSurvey> FilledSurveys { get; set; }

#pragma warning restore CS8618

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("User ID=postgres;Password=root;Host=localhost;Port=5432;Database=SISGEP;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new PersonMap());
            modelBuilder.ApplyConfiguration(new AddressMap());
            modelBuilder.ApplyConfiguration(new ProjectMap());
            modelBuilder.ApplyConfiguration(new SurveyMap());
            modelBuilder.ApplyConfiguration(new FilledSurveyMap());
        }
    }
}