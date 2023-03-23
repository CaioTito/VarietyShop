using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VarietyShop.Domain.Entities;

namespace VarietyShop.Infra.Persistence.Data.Mappings;

public class ActivityMap : IEntityTypeConfiguration<Activity>
{
    public void Configure(EntityTypeBuilder<Activity> builder)
    {
        builder.ToTable(nameof(Activity));

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
                .ValueGeneratedOnAdd()
                .UseIdentityColumn();

        builder.Property(x => x.Name)
                .IsRequired()
                .HasColumnName(nameof(Activity.Name))
                .HasColumnType("NVARCHAR")
                .HasMaxLength(40);

        builder.Property(x => x.Quantity)
                .IsRequired()
                .HasColumnName(nameof(Activity.Quantity))
                .HasDefaultValue(0);

        builder.Property(x => x.Value)
                .IsRequired()
                .HasColumnName(nameof(Activity.Value))
                .HasColumnType("NUMERIC(10,2)")
                .HasDefaultValue(0.00M);

        builder.Property(x => x.CreateDate)
                .IsRequired()
                .HasColumnName(nameof(Activity.CreateDate))
                .HasColumnType("SMALLDATETIME")
                .HasDefaultValue(DateTime.Now.ToUniversalTime());

        builder.Property(x => x.LastUpdateDate)
                .IsRequired()
                .HasColumnName(nameof(Activity.LastUpdateDate))
                .HasColumnType("SMALLDATETIME")
                .HasDefaultValue(DateTime.Now.ToUniversalTime());

        builder.Property(x => x.Slug)
                .IsRequired()
                .HasColumnName(nameof(Activity.Slug))
                .HasColumnType("VARCHAR")
                .HasMaxLength(20);

        builder.Property(x => x.Active)
                .IsRequired()
                .HasColumnName(nameof(Activity.Active))
                .HasColumnType("BIT")
                .HasDefaultValue(false);

        builder.HasOne(x => x.Client)
                .WithMany(x => x.Activities)
                .HasForeignKey(x => x.ClientId)
                .HasConstraintName("FK_Activity_Client");

        builder.HasMany(x => x.Products)
                .WithMany(x => x.Activities)
                .UsingEntity<Dictionary<string, object>>(
                "ActivityProduct",
                product => product.HasOne<Product>()
                    .WithMany()
                    .HasForeignKey("ProductId")
                    .HasConstraintName("FK_ActivityProduct_ProductId")
                    .OnDelete(DeleteBehavior.Cascade),
                activity => activity.HasOne<Activity>()
                    .WithMany()
                    .HasForeignKey("ActivityId")
                    .HasConstraintName("FK_ActivityProduct_ActivityId")
                    .OnDelete(DeleteBehavior.Cascade));
    }
}
