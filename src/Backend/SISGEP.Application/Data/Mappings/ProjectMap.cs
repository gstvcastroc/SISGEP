using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using SISGEP.Application.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SISGEP.Application.Data.Mappings
{
    public class ProjectMap : IEntityTypeConfiguration<Project>
    {
        public void Configure(EntityTypeBuilder<Project> builder)
        {
            builder.ToTable("projects");

            builder
                .HasKey(project => project.Id);

            builder
                .Property(project => project.Id);

            builder
                .Property(project => project.Name)
                .HasColumnType("varchar(32)")
                .IsRequired();

            builder
                .Property(project => project.Description)
                .HasColumnType("varchar(256)")
                .IsRequired();

            builder
                .Property(project => project.IsActive)
                .HasColumnType("boolean")
                .IsRequired();

            builder
                .Property(project => project.StartDate)
                .HasColumnType("date")
                .IsRequired();

            builder
                .Property(project => project.EndDate)
                .HasColumnType("date")
                .IsRequired();

            builder
                .HasOne(project => project.Questionnaire)
                .WithOne(questionnaire => questionnaire.Project)
                .HasForeignKey<Questionnaire>(questionnaire => questionnaire.ProjectId);
        }
    }
}
