using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TFA.Backend.Infrastructure.Persistence.Models;

namespace TFA.Backend.Infrastructure.Persistence.Configurations
{
    public class OrderConfiguration : IEntityTypeConfiguration<OrderModel>
    {
        public void Configure(EntityTypeBuilder<OrderModel> builder)
        {
            builder.ToTable("Orders");
            builder.HasKey(x => x.OrderID);
            builder.Property(x => x.CustomerID).HasColumnType("uuid").IsRequired();
            builder.Property(x => x.EmployeeID).HasColumnType("uuid").IsRequired();
            builder.Property(x => x.OrderDate).HasColumnType("timestamp").IsRequired();
            builder.Property(x => x.ShippedDate).HasColumnType("timestamp").IsRequired();
            builder.Property(x => x.ShipVia).HasColumnType("uuid").IsRequired();
            builder.Property(x => x.Freight).HasColumnType("varchar(50)").IsRequired(false);
            builder.Property(x => x.ShipName).HasColumnType("varchar(50)").IsRequired(false);
            builder.Property(x => x.ShipAddress).HasColumnType("varchar(100)").IsRequired(false);
            builder.Property(x => x.ShipCity).HasColumnType("varchar(50)").IsRequired(false);
            builder.Property(x => x.ShipRegion).HasColumnType("varchar(50)").IsRequired(false);
            builder.Property(x => x.ShipPostalCode).HasColumnType("varchar(20)").IsRequired(false);
            builder.Property(x => x.ShipCountry).HasColumnType("varchar(50)").IsRequired(false);
        }
    }
}
