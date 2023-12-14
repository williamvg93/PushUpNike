using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities.Inventory;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Config.Inventory;

public class ProductConfig : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.HasKey(e => e.Id).HasName("PRIMARY");

        builder.ToTable("product");

        builder.HasIndex(e => e.FkIdColor, "FK_pordColor");

        builder.HasIndex(e => e.FkIdProdCategory, "FK_prodCate");

        builder.HasIndex(e => e.FkIdtGenderType, "FK_prodGenderType");

        builder.Property(e => e.Id).HasColumnName("id");
        builder.Property(e => e.FkIdColor).HasColumnName("fkIdColor");
        builder.Property(e => e.FkIdOrderDetail).HasColumnName("fkIdOrderDetail");
        builder.Property(e => e.FkIdProdCategory).HasColumnName("fkIdProdCategory");
        builder.Property(e => e.FkIdtGenderType).HasColumnName("fkIdtGenderType");
        builder.Property(e => e.Name)
            .IsRequired()
            .HasMaxLength(50)
            .HasColumnName("name");

        builder.HasOne(d => d.FkIdColorNavigation).WithMany(p => p.Products)
            .HasForeignKey(d => d.FkIdColor)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("FK_pordColor");

        builder.HasOne(d => d.FkIdProdCategoryNavigation).WithMany(p => p.Products)
            .HasForeignKey(d => d.FkIdProdCategory)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("FK_prodCate");

        builder.HasOne(d => d.FkIdtGenderTypeNavigation).WithMany(p => p.Products)
            .HasForeignKey(d => d.FkIdtGenderType)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("FK_prodGenderType");
    }
}