using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities.Location;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Config.Location;

public class CityConfig : IEntityTypeConfiguration<City>
{
    public void Configure(EntityTypeBuilder<City> builder)
    {
        builder.HasKey(e => e.Id).HasName("PRIMARY");

        builder.ToTable("city");

        builder.HasIndex(e => e.FkIdDepartment, "FK_deparCity");

        builder.Property(e => e.Id).HasColumnName("id");
        builder.Property(e => e.FkIdDepartment).HasColumnName("fkIdDepartment");
        builder.Property(e => e.Name)
            .IsRequired()
            .HasMaxLength(50);

        builder.HasOne(d => d.FkIdDepartmentNavigation).WithMany(p => p.Cities)
            .HasForeignKey(d => d.FkIdDepartment)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("FK_deparCity");
    }
}