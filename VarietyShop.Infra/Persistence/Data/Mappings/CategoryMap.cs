﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VarietyShop.Domain.Entities;

namespace VarietyShop.Infra.Persistence.Data.Mappings;

public class CategoryMap : IEntityTypeConfiguration<Category>
{
    public void Configure(EntityTypeBuilder<Category> builder)
    {
        builder.ToTable(nameof(Category));

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
                .ValueGeneratedOnAdd()
                .UseIdentityColumn();

        builder.Property(x => x.Name)
                .IsRequired()
                .HasColumnName(nameof(Category.Name))
                .HasColumnType("NVARCHAR")
                .HasMaxLength(80);

        builder.Property(x => x.Slug)
                .IsRequired()
                .HasColumnName(nameof(Category.Slug))
                .HasColumnType("VARCHAR")
                .HasMaxLength(20);

        builder.Property(x => x.Active)
                .IsRequired()
                .HasColumnName(nameof(Category.Active))
                .HasColumnType("BIT")
                .HasDefaultValue(false);

        builder.HasIndex(x => x.Slug, "IX_Category_Slug")
                .IsUnique();
    }
}
