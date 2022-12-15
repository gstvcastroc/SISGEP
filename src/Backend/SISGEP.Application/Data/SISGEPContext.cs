using Microsoft.EntityFrameworkCore;
using SISGEP.Application.Data.Mappings;
using SISGEP.Application.Entities;

namespace SISGEP.Application.Data
{
    public class SISGEPContext : DbContext
    {
        public DbSet<Person> Persons { get; set; }

        public DbSet<Address> Addresses { get; set; }

        public DbSet<Project> Projects { get; set; }

        public DbSet<Survey> Surveys { get; set; }

        public DbSet<FilledSurvey> FilledSurveys { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("")
                .EnableSensitiveDataLogging();
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
