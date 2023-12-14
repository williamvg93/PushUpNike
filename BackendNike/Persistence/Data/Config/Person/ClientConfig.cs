using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities.Person;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Config.Person;

public class ClientConfig : IEntityTypeConfiguration<Client>
{
    public void Configure(EntityTypeBuilder<Client> builder)
    {
        builder.HasKey(e => e.Id).HasName("PRIMARY");

        builder.ToTable("client");

        builder.HasIndex(e => e.FkIdContact, "FK_clientContact");

        builder.HasIndex(e => e.Code, "code").IsUnique();

        builder.HasIndex(e => e.FkIdAddress, "fkIdAddress").IsUnique();

        builder.Property(e => e.Id).HasColumnName("id");
        builder.Property(e => e.Age).HasColumnName("age");
        builder.Property(e => e.Code)
            .IsRequired()
            .HasMaxLength(30)
            .HasColumnName("code");
        builder.Property(e => e.CreationDate)
            .HasColumnType("datetime")
            .HasColumnName("creationDate");
        builder.Property(e => e.Email)
            .IsRequired()
            .HasMaxLength(50)
            .HasColumnName("email");
        builder.Property(e => e.FkIdAddress).HasColumnName("fkIdAddress");
        builder.Property(e => e.FkIdContact).HasColumnName("fkIdContact");
        builder.Property(e => e.LastName)
            .IsRequired()
            .HasMaxLength(50)
            .HasColumnName("lastName");
        builder.Property(e => e.Name)
            .IsRequired()
            .HasMaxLength(50)
            .HasColumnName("name");

        builder.HasOne(d => d.FkIdAddressNavigation).WithOne(p => p.Client)
            .HasForeignKey<Client>(d => d.FkIdAddress)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("FK_clientAddress");

        builder.HasOne(d => d.FkIdContactNavigation).WithMany(p => p.Clients)
            .HasForeignKey(d => d.FkIdContact)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("FK_clientContact");
    }
}