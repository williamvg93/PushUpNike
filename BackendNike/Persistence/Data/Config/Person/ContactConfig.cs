using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities.Person;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Config.Person;

public class ContactConfig : IEntityTypeConfiguration<Contact>
{
    public void Configure(EntityTypeBuilder<Contact> builder)
    {
        builder.HasKey(e => e.Id).HasName("PRIMARY");

        builder.ToTable("contact");

        builder.HasIndex(e => e.FkIdContactType, "FK_contConType");

        builder.Property(e => e.Id).HasColumnName("id");
        builder.Property(e => e.FkIdContactType).HasColumnName("fkIdContactType");
        builder.Property(e => e.Number)
            .IsRequired()
            .HasMaxLength(30)
            .HasColumnName("number");

        builder.HasOne(d => d.FkIdContactTypeNavigation).WithMany(p => p.Contacts)
            .HasForeignKey(d => d.FkIdContactType)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("FK_contConType");
    }
}