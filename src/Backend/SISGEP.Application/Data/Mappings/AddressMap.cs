using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SISGEP.Application.Entities;

namespace SISGEP.Application.Data.Mappings
{
    public class AddressMap : IEntityTypeConfiguration<Address>
    {
        public void Configure(EntityTypeBuilder<Address> builder)
        {
            builder.ToTable("address");

            builder
                .HasKey(address => address.AddressId);

            builder
                .Property(address => address.AddressId);

            builder
                .Property(address => address.PostalCode)
                .HasColumnType("varchar(8)")
                .IsRequired();

            builder
                .Property(address => address.Thoroughfare)
                .HasColumnType("varchar(256)")
                .IsRequired();

            builder
                .Property(address => address.Number)
                .HasColumnType("smallserial")
                .IsRequired();

            builder
                .Property(address => address.Neighborhood)
                .HasColumnType("varchar(64)")
                .IsRequired();

            builder
                .Property(address => address.Complement)
                .HasColumnType("varchar(128)");

            builder
                .Property(address => address.City)
                .HasColumnType("varchar(64)")
                .IsRequired();

            builder
                .Property(address => address.State)
                .HasColumnType("varchar(16)")
                .IsRequired();
        }
    }
}
