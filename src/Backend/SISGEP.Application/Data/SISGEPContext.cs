using Microsoft.EntityFrameworkCore;
using SISGEP.Application.Entities;

namespace SISGEP.Application.Data
{
    public class SISGEPContext : DbContext
    {
#pragma warning disable CS8618

        public DbSet<Person> Persons { get; set; }

        public DbSet<Address> Addresses { get; set; }

        public DbSet<Project> Projects { get; set; }

        public DbSet<Questionnaire> Questionnaires { get; set; }

        public DbSet<AnsweredQuestionnaire> AnsweredQuestionnaires { get; set; }

#pragma warning restore CS8618

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // TODO: adjust connection string.
            optionsBuilder.UseNpgsql("Data Source=localhost;Initial Catalog=SISGEP;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // TODO: create database mappings and apply them.
        }
    }
}