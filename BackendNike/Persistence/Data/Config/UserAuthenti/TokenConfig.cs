using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities.UserAuthenti;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Config.UserAuthenti;

public class TokenConfig : IEntityTypeConfiguration<Token>
{
    public void Configure(EntityTypeBuilder<Token> builder)
    {
        builder.HasKey(e => e.Id).HasName("PRIMARY");

        builder.ToTable("token");

        builder.HasIndex(e => e.FkIdUser, "FK_tokenUser");

        builder.HasIndex(e => e.Code, "code").IsUnique();

        builder.Property(e => e.Id).HasColumnName("id");
        builder.Property(e => e.Code)
            .IsRequired()
            .HasMaxLength(70)
            .HasColumnName("code");
        builder.Property(e => e.CreationDate)
            .HasColumnType("datetime")
            .HasColumnName("creationDate");
        builder.Property(e => e.FkIdUser).HasColumnName("fkIdUser");

        builder.HasOne(d => d.FkIdUserNavigation).WithMany(p => p.Tokens)
            .HasForeignKey(d => d.FkIdUser)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("FK_tokenUser");
    }
}