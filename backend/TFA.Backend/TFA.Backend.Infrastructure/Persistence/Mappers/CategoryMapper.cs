using TFA.Backend.Domain.Entities;
using TFA.Backend.Infrastructure.Persistence.Models;

namespace TFA.Backend.Infrastructure.Persistence.Mappers
{
    public static class CategoryMapper
    {
        public static CategoryModel ToModel(this Category category)
        {
            if (category == null) return null;
            return new CategoryModel
            {
                CategoryID = category.CategoryID,
                CategoryName = category.CategoryName,
                Description = category.Description,
                Picture = category.Picture
            };
        }
        public static Category ToEntity(this CategoryModel categoryModel)
        {
            if (categoryModel == null) return null;
            return new Category
            {
                CategoryID = categoryModel.CategoryID,
                CategoryName = categoryModel.CategoryName,
                Description = categoryModel.Description,
                Picture = categoryModel.Picture
            };
        }
    }
}
