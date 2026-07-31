using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TFA.Backend.Infrastructure.Persistence.Models;

namespace TFA.Backend.Infrastructure.Persistence.Configurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<ProductModel>
    {
        public void Configure(EntityTypeBuilder<ProductModel> builder)
        {
            builder.ToTable("Products");
            builder.HasKey(x => x.ProductID);
            builder.Property(x => x.ProductName).HasColumnType("varchar(50)").IsRequired();
            builder.Property(x => x.SupplierID).HasColumnType("uuid").IsRequired();
            builder.Property(x => x.CategoryID).HasColumnType("uuid").IsRequired();
            builder.Property(x => x.QuantityPerUnit).HasColumnType("decimal(18, 2)").IsRequired();
            builder.Property(x => x.UnitPrice).HasColumnType("decimal(18, 2)").IsRequired();
            builder.Property(x => x.UnitsInStock).HasColumnType("decimal(18, 2)").IsRequired();
            builder.Property(x => x.UnitsOnOrder).HasColumnType("decimal(18, 2)").IsRequired();
            builder.Property(x => x.ReorderLevel).HasColumnType("decimal(18, 2)").IsRequired();
            builder.Property(x => x.Discontinued).HasColumnType("int").IsRequired();

            builder.HasOne(x => x.Category)
                .WithMany(x => x.Products)
                .HasForeignKey(x => x.CategoryID)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(x => x.Supplier)
                .WithMany(x => x.Products)
                .HasForeignKey(x => x.SupplierID)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
