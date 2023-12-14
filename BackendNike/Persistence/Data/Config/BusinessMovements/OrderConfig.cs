using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities.BusinessMovements;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Config.BusinessMovements;

public class OrderConfig : IEntityTypeConfiguration<Order>
{
    public void Configure(EntityTypeBuilder<Order> builder)
    {
        builder.HasKey(e => e.Id).HasName("PRIMARY");

        builder.ToTable("order");

        builder.HasIndex(e => e.FkIdClient, "FK_orderClient");

        builder.HasIndex(e => e.FkIdPaymentType, "FK_orderPayType");

        builder.HasIndex(e => e.FkIdStatus, "FK_orderStatus");

        builder.Property(e => e.Id).HasColumnName("id");
        builder.Property(e => e.CreationDate)
            .HasColumnType("datetime")
            .HasColumnName("creationDate");
        builder.Property(e => e.FkIdClient).HasColumnName("fkIdClient");
        builder.Property(e => e.FkIdPaymentType).HasColumnName("fkIdPaymentType");
        builder.Property(e => e.FkIdStatus).HasColumnName("fkIdStatus");

        builder.HasOne(d => d.FkIdClientNavigation).WithMany(p => p.Orders)
            .HasForeignKey(d => d.FkIdClient)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("FK_orderClient");

        builder.HasOne(d => d.FkIdPaymentTypeNavigation).WithMany(p => p.Orders)
            .HasForeignKey(d => d.FkIdPaymentType)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("FK_orderPayType");

        builder.HasOne(d => d.FkIdStatusNavigation).WithMany(p => p.Orders)
            .HasForeignKey(d => d.FkIdStatus)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("FK_orderStatus");
    }
}