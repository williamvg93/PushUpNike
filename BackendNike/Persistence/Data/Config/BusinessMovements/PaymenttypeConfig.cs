using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities.BusinessMovements;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Config.BusinessMovements;

public class PaymenttypeConfig : IEntityTypeConfiguration<Paymenttype>
{
    public void Configure(EntityTypeBuilder<Paymenttype> builder)
    {
        builder.HasKey(e => e.Id).HasName("PRIMARY");

        builder.ToTable("paymenttype");

        builder.HasIndex(e => e.Name, "Name").IsUnique();

        builder.Property(e => e.Id).HasColumnName("id");
        builder.Property(e => e.Name)
            .IsRequired()
            .HasMaxLength(50);
    }
}