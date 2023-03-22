using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VarietyShop.Domain.Models;

namespace VarietyShop.Infra.Persistence.Data.Mappings;

public class RoleMap : IEntityTypeConfiguration<Role>
{
    public void Configure(EntityTypeBuilder<Role> builder)
    {
        builder.ToTable(nameof(Role));

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
                .ValueGeneratedOnAdd()
                .UseIdentityColumn();

        builder.Property(x => x.Name)
                .IsRequired()
                .HasColumnName(nameof(Role.Name))
                .HasColumnType("VARCHAR")
                .HasMaxLength(20);

        builder.Property(x => x.Slug)
                .IsRequired()
                .HasColumnName(nameof(Role.Slug))
                .HasColumnType("VARCHAR")
                .HasMaxLength(20);

        builder.Property(x => x.Active)
                .IsRequired()
                .HasColumnName(nameof(Role.Active))
                .HasColumnType("BIT")
                .HasDefaultValue(false);

        builder.HasIndex(x => x.Slug, "IX_Role_Slug")
                .IsUnique();
    }
}
