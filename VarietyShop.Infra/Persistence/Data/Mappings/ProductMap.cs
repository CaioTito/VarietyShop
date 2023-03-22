using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VarietyShop.Domain.Models;

namespace VarietyShop.Infra.Persistence.Data.Mappings;

public class ProductMap : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.ToTable(nameof(Product));

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
                .ValueGeneratedOnAdd()
                .UseIdentityColumn();

        builder.Property(x => x.Name)
                .IsRequired()
                .HasColumnName(nameof(Product.Name))
                .HasColumnType("NVARCHAR")
                .HasMaxLength(40);

        builder.Property(x => x.Quantity)
                .IsRequired()
                .HasColumnName(nameof(Product.Quantity))
                .HasDefaultValue(0);

        builder.Property(x => x.Value)
                .IsRequired()
                .HasColumnName(nameof(Product.Value))
                .HasColumnType("NUMERIC(10,2)")
                .HasDefaultValue(0.00M);

        builder.Property(x => x.Slug)
                .IsRequired()
                .HasColumnName(nameof(Product.Slug))
                .HasColumnType("VARCHAR")
                .HasMaxLength(20);

        builder.Property(x => x.Active)
                .IsRequired()
                .HasColumnName(nameof(Product.Active))
                .HasColumnType("BIT")
                .HasDefaultValue(false);

        builder.Property(x => x.EntryDate)
                .IsRequired()
                .HasColumnName(nameof(Product.EntryDate))
                .HasColumnType("SMALLDATETIME")
                .HasDefaultValue(DateTime.Now.ToUniversalTime());

        builder.HasIndex(x => x.Name, "IX_Product_Name");

        builder.HasOne(x => x.Category)
                .WithMany(x => x.Products)
                .HasForeignKey(x => x.CategoryId)
                .HasConstraintName("FK_Product_Category")
                .OnDelete(DeleteBehavior.Cascade);
    }
}
