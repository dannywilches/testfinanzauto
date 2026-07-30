using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TFA.Backend.Infrastructure.Persistence.Models;

namespace TFA.Backend.Infrastructure.Persistence.Configurations
{
    public class ShipperConfiguration : IEntityTypeConfiguration<ShipperModel>
    {
        public void Configure(EntityTypeBuilder<ShipperModel> builder)
        {
            builder.ToTable("Shippers");
            builder.HasKey(x => x.ShipperID);
            builder.Property(x => x.CompanyName).HasColumnType("varchar(50)").IsRequired();
            builder.Property(x => x.Phone).HasColumnType("varchar(30)").IsRequired(false);
        }
    }
}
