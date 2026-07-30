using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TFA.Backend.Infrastructure.Persistence.Models;

namespace TFA.Backend.Infrastructure.Persistence.Configurations
{
    public class OrderDetailConfiguration : IEntityTypeConfiguration<OrderDetailModel>
    {
        public void Configure(EntityTypeBuilder<OrderDetailModel> builder)
        {
            builder.ToTable("OrderDetails");
            builder.HasKey(x => new { x.OrderID, x.ProductID });
            builder.Property(x => x.UnitPrice).HasColumnType("decimal(18, 2)").IsRequired();
            builder.Property(x => x.Quantity).HasColumnType("smallint").IsRequired();
            builder.Property(x => x.Discount).HasColumnType("real").IsRequired();
        }
    }
}
