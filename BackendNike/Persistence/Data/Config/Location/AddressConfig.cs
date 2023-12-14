using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities.Location;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Config.Location;

public class AddressConfig : IEntityTypeConfiguration<Address>
{
    public void Configure(EntityTypeBuilder<Address> builder)
    {
        builder.HasKey(e => e.Id).HasName("PRIMARY");

        builder.ToTable("address");

        builder.HasIndex(e => e.FkIdAddressType, "FK_addressAddreType");

        builder.HasIndex(e => e.IkIdCity, "FK_addressCity");

        builder.Property(e => e.Id).HasColumnName("id");
        builder.Property(e => e.Complement)
            .HasMaxLength(50)
            .HasColumnName("complement");
        builder.Property(e => e.Description)
            .IsRequired()
            .HasMaxLength(50)
            .HasColumnName("description");
        builder.Property(e => e.FkIdAddressType).HasColumnName("fkIdAddressType");

        builder.HasOne(d => d.FkIdAddressTypeNavigation).WithMany(p => p.Addresses)
            .HasForeignKey(d => d.FkIdAddressType)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("FK_addressAddreType");

        builder.HasOne(d => d.IkIdCityNavigation).WithMany(p => p.Addresses)
            .HasForeignKey(d => d.IkIdCity)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("FK_addressCity");
    }
}