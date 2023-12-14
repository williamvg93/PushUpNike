using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities.BusinessMovements;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Config.BusinessMovements;

public class OrderdetailConfig : IEntityTypeConfiguration<Orderdetail>
{
    public void Configure(EntityTypeBuilder<Orderdetail> builder)
    {
        builder.HasKey(e => e.Id).HasName("PRIMARY");

        builder.ToTable("orderdetail");

        builder.HasIndex(e => e.FkIdOrder, "FK_ordeDetOrder");

        builder.HasIndex(e => e.FkIdProduct, "FK_ordeDetProd");

        builder.Property(e => e.Id).HasColumnName("id");
        builder.Property(e => e.FkIdOrder).HasColumnName("fkIdOrder");
        builder.Property(e => e.FkIdProduct).HasColumnName("fkIdProduct");

        builder.HasOne(d => d.FkIdOrderNavigation).WithMany(p => p.Orderdetails)
            .HasForeignKey(d => d.FkIdOrder)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("FK_ordeDetOrder");

        builder.HasOne(d => d.FkIdProductNavigation).WithMany(p => p.Orderdetails)
            .HasForeignKey(d => d.FkIdProduct)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("FK_ordeDetProd");
    }
}