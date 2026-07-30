using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TFA.Backend.Infrastructure.Persistence.Models;

namespace TFA.Backend.Infrastructure.Persistence.Configurations
{
    public class EmployeeConfiguration : IEntityTypeConfiguration<EmployeeModel>
    {
        public void Configure(EntityTypeBuilder<EmployeeModel> builder)
        {
            builder.ToTable("Employees");
            builder.HasKey(x => x.EmployeeID);
            builder.Property(x => x.LastName).HasColumnType("varchar(50)").IsRequired();
            builder.Property(x => x.FirstName).HasColumnType("varchar(50)").IsRequired();
            builder.Property(x => x.Title).HasColumnType("varchar(50)").IsRequired(false);
            builder.Property(x => x.TitleOfCourtesy).HasColumnType("varchar(50)").IsRequired(false);
            builder.Property(x => x.BirthDate).HasColumnType("timestamp").IsRequired();
            builder.Property(x => x.HireDate).HasColumnType("timestamp").IsRequired();
            builder.Property(x => x.Address).HasColumnType("varchar(100)").IsRequired(false);
            builder.Property(x => x.City).HasColumnType("varchar(50)").IsRequired(false);
            builder.Property(x => x.Region).HasColumnType("varchar(50)").IsRequired(false);
            builder.Property(x => x.PostalCode).HasColumnType("varchar(20)").IsRequired(false);
            builder.Property(x => x.Country).HasColumnType("varchar(50)").IsRequired(false);
            builder.Property(x => x.HomePhone).HasColumnType("varchar(30)").IsRequired(false);
            builder.Property(x => x.Extension).HasColumnType("varchar(10)").IsRequired(false);
            builder.Property(x => x.Photo).HasColumnType("text").IsRequired(false);
            builder.Property(x => x.Notes).HasColumnType("text").IsRequired(false);
            builder.Property(x => x.ReportsTo).HasColumnType("text").IsRequired(false);
        }
    }
}
