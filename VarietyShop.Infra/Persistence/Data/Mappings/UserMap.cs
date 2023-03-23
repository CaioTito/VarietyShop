using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Collections.Generic;
using VarietyShop.Domain.Models;

namespace VarietyShop.Infra.Persistence.Data.Mappings;

public class UserMap : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable(nameof(User));

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
                .ValueGeneratedOnAdd()
                .UseIdentityColumn();

        builder.Property(x => x.Name)
                .IsRequired()
                .HasColumnName(nameof(User.Name))
                .HasColumnType("NVARCHAR")
                .HasMaxLength(80);

        builder.Property(x => x.Cpf)
                .IsRequired()
                .HasColumnName(nameof(User.Cpf))
                .HasColumnType("VARCHAR")
                .HasMaxLength(14)
                .IsFixedLength();

        builder.Property(x => x.Email)
                .IsRequired()
                .HasColumnName(nameof(User.Email))
                .HasColumnType("VARCHAR")
                .HasMaxLength(80);

        builder.Property(x => x.PasswordHash)
                .IsRequired()
                .HasColumnName(nameof(User.PasswordHash))
                .HasColumnType("VARCHAR")
                .HasMaxLength(255);

        builder.Property(x => x.Slug)
                .IsRequired()
                .HasColumnName(nameof(User.Slug))
                .HasColumnType("VARCHAR")
                .HasMaxLength(20);

        builder.Property(x => x.Active)
                .IsRequired()
                .HasColumnName(nameof(User.Active))
                .HasColumnType("BIT")
                .HasDefaultValue(false);

        builder.HasIndex(x => x.Email, "IX_User_Email")
                .IsUnique();

        builder.HasMany(x => x.Roles)
                .WithMany(x => x.Users)
                .UsingEntity<Dictionary<string, object>>(
                "UserRole",
                role => role.HasOne<Role>()
                    .WithMany()
                    .HasForeignKey("RoleId")
                    .HasConstraintName("FK_UserRole_RoleId")
                    .OnDelete(DeleteBehavior.Cascade),
                user => user.HasOne<User>()
                    .WithMany()
                    .HasForeignKey("UserId")
                    .HasConstraintName("FK_UserRole_UserId")
                    .OnDelete(DeleteBehavior.Cascade));
    }
}
