using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using SISGEP.Application.Entities;

namespace SISGEP.Application.Data.Mappings
{
    public class ProjectMap : IEntityTypeConfiguration<Project>
    {
        public void Configure(EntityTypeBuilder<Project> builder)
        {
            builder.ToTable("projects");

            builder
                .HasKey(project => project.ProjectId);

            builder
                .Property(project => project.ProjectId);

            builder
                .Property(project => project.Name)
                .HasColumnType("varchar(32)")
                .IsRequired();

            builder
                .Property(project => project.Description)
                .HasColumnType("varchar(256)");

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
                .HasColumnType("date");
        }
    }
}
