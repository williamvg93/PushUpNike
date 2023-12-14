using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities.UserAuthenti;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Config.UserAuthenti;

public class UserConfig : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasKey(e => e.Id).HasName("PRIMARY");

        builder.ToTable("user");

        builder.HasIndex(e => e.FkIdClient, "FK_userClient");

        builder.HasIndex(e => e.FkIdRol, "FK_userRol");

        builder.Property(e => e.Id).HasColumnName("id");
        builder.Property(e => e.CreationDate)
            .HasColumnType("datetime")
            .HasColumnName("creationDate");
        builder.Property(e => e.FkIdClient).HasColumnName("fkIdClient");
        builder.Property(e => e.FkIdRol).HasColumnName("fkIdRol");
        builder.Property(e => e.Name)
            .IsRequired()
            .HasMaxLength(50)
            .HasColumnName("name");
        builder.Property(e => e.Password)
            .IsRequired()
            .HasMaxLength(30)
            .HasColumnName("password");

        builder.HasOne(d => d.FkIdClientNavigation).WithMany(p => p.Users)
            .HasForeignKey(d => d.FkIdClient)
            .HasConstraintName("FK_userClient");

        builder.HasOne(d => d.FkIdRolNavigation).WithMany(p => p.Users)
            .HasForeignKey(d => d.FkIdRol)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("FK_userRol");
    }
}