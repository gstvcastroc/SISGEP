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
    public class PersonMap : IEntityTypeConfiguration<Person>
    {
        public void Configure(EntityTypeBuilder<Person> builder)
        {
            builder.ToTable("persons");

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
                .HasColumnType("varchar(9)")
                .IsRequired();

            builder
                .Property(person => person.PersonType)
                .HasColumnType("varchar(9)")
                .HasConversion<string>()
                .IsRequired();
        }
    }
}
