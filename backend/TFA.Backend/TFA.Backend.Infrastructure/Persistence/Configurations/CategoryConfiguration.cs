using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TFA.Backend.Infrastructure.Persistence.Models;

namespace TFA.Backend.Infrastructure.Persistence.Configurations
{
    public class CategoryConfiguration : IEntityTypeConfiguration<CategoryModel>
    {
        public void Configure(EntityTypeBuilder<CategoryModel> builder)
        {
            builder.ToTable("Categories");
            builder.HasKey(x => x.CategoryID);
            builder.Property(x => x.CategoryName).HasColumnType("varchar(50)").IsRequired();
            builder.Property(x => x.Description).HasColumnType("text").IsRequired(false);
            builder.Property(x => x.Picture).HasColumnType("text").IsRequired(false);

            builder.HasMany(x => x.Products)
                .WithOne(x => x.Category)
                .HasForeignKey(x => x.CategoryID);
        }
    }
}
