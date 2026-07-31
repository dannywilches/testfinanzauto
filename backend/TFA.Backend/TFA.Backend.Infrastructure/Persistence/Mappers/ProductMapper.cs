using TFA.Backend.Domain.Entities;
using TFA.Backend.Infrastructure.Persistence.Models;

namespace TFA.Backend.Infrastructure.Persistence.Mappers
{
    public static class ProductMapper
    {
        public static ProductModel ToModel(Product product)
        {
            if (product == null) return null;
            return new ProductModel
            {
                ProductID = product.ProductID,
                ProductName = product.ProductName,
                SupplierID = product.SupplierID,
                CategoryID = product.CategoryID,
                QuantityPerUnit = product.QuantityPerUnit,
                UnitPrice = product.UnitPrice,
                UnitsInStock = product.UnitsInStock,
                UnitsOnOrder = product.UnitsOnOrder,
                ReorderLevel = product.ReorderLevel,
                Discontinued = product.Discontinued
            };
        }

        public static Product ToEntity(ProductModel product)
        {
            if (product == null) return null;
            return new Product
            {
                ProductID = product.ProductID,
                ProductName = product.ProductName,
                SupplierID = product.SupplierID,
                CategoryID = product.CategoryID,
                QuantityPerUnit = product.QuantityPerUnit,
                UnitPrice = product.UnitPrice,
                UnitsInStock = product.UnitsInStock,
                UnitsOnOrder = product.UnitsOnOrder,
                ReorderLevel = product.ReorderLevel,
                Discontinued = product.Discontinued,
                Category = product.Category != null ? CategoryMapper.ToEntity(product.Category) : null,
                Supplier = product.Supplier != null ? SupplierMapper.ToEntity(product.Supplier) : null
            };
        }
    }
}
