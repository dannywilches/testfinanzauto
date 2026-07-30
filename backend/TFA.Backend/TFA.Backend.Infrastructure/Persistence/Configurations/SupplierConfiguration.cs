using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TFA.Backend.Infrastructure.Persistence.Models;

namespace TFA.Backend.Infrastructure.Persistence.Configurations
{
    public class SupplierConfiguration : IEntityTypeConfiguration<SupplierModel>
    {
        public void Configure(EntityTypeBuilder<SupplierModel> builder)
        {
            builder.ToTable("Suppliers");
            builder.HasKey(x => x.SupplierID);
            builder.Property(x => x.CompanyName).HasColumnType("varchar(50)").IsRequired();
            builder.Property(x => x.ContactName).HasColumnType("varchar(50)").IsRequired(false);
            builder.Property(x => x.ContactTitle).HasColumnType("varchar(50)").IsRequired(false);
            builder.Property(x => x.Address).HasColumnType("varchar(100)").IsRequired(false);
            builder.Property(x => x.City).HasColumnType("varchar(50)").IsRequired(false);
            builder.Property(x => x.Region).HasColumnType("varchar(50)").IsRequired(false);
            builder.Property(x => x.PostalCode).HasColumnType("varchar(20)").IsRequired(false);
            builder.Property(x => x.Country).HasColumnType("varchar(50)").IsRequired(false);
            builder.Property(x => x.Phone).HasColumnType("varchar(30)").IsRequired(false);
            builder.Property(x => x.Fax).HasColumnType("varchar(30)").IsRequired(false);
        }
    }
}
