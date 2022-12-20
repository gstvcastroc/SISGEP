using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SISGEP.Application.Entities;

namespace SISGEP.Application.Data.Mappings
{
    public class PersonMap : IEntityTypeConfiguration<Person>
    {
        public void Configure(EntityTypeBuilder<Person> builder)
        {
            builder.ToTable("person");

            builder
                .HasKey(person => person.PersonId);

            builder
                .Property(person => person.PersonId);

            builder
                .Property(person => person.Name)
                .HasColumnType("varchar(256)")
                .IsRequired();

            builder
                .Property(person => person.Email)
                .HasColumnType("varchar(256)")
                .IsRequired();

            builder
                .Property(person => person.Password)
                .HasColumnType("varchar(256)")
                .IsRequired();

            builder
                .Property(person => person.IsActive)
                .HasColumnType("boolean")
                .IsRequired();

            builder
                .Property(person => person.Cpf)
                .HasColumnType("varchar(11)")
                .IsRequired();

            builder
                .Property(person => person.PersonType)
                .HasColumnType("varchar(9)")
                .HasConversion<string>()
                .IsRequired();
        }
    }
}
