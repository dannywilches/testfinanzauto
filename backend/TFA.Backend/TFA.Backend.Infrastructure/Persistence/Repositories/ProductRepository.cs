using Microsoft.EntityFrameworkCore;
using TFA.Backend.Domain.Common;
using TFA.Backend.Domain.Entities;
using TFA.Backend.Domain.Filters;
using TFA.Backend.Domain.Repositories;
using TFA.Backend.Infrastructure.Persistence.Context;
using TFA.Backend.Infrastructure.Persistence.Mappers;
using TFA.Backend.Infrastructure.Persistence.Models;

namespace TFA.Backend.Infrastructure.Persistence.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly CatalogDbContext _dbContext;

        public ProductRepository(CatalogDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<Product?> CreateProduct(Product product, CancellationToken ct = default)
        {
            var productModel = ProductMapper.ToModel(product);
            var createdProduct = await _dbContext.Products.AddAsync(productModel, ct);
            await _dbContext.SaveChangesAsync(ct);
            return ProductMapper.ToEntity(createdProduct.Entity);
        }

        public async Task<bool> DeleteProduct(Guid productId, CancellationToken ct = default)
        {
            var product = await _dbContext.Products.FirstOrDefaultAsync(p => p.ProductID == productId, ct);
            if (product == null)
                return false;
            _dbContext.Products.Remove(product);
            await _dbContext.SaveChangesAsync(ct);
            return true;
        }

        public async Task<List<Product>> GetAllProducts(CancellationToken ct = default)
        {
            var products = await _dbContext.Products
                .AsNoTracking()
                .ToListAsync(ct);
            return products.Select(ProductMapper.ToEntity).ToList();
        }

        public async Task<PagedResult<Product>> GetAllProductsPaged(ProductFilter filter, CancellationToken ct = default)
        {
            var query = _dbContext.Products
                .AsNoTracking()
                .Include(x => x.Category)
                .AsQueryable();

            // Filtro Categoria
            if (!string.IsNullOrEmpty(filter.Category))
            {
                query = query
                    .Where(p => p.Category.CategoryName == filter.Category);
            }

            // Filtro de búsqueda
            if (!string.IsNullOrWhiteSpace(filter.Search))
            {
                query = query
                    .Where(p => p.ProductName.Contains(filter.Search, StringComparison.OrdinalIgnoreCase));
            }

            var totalItems = await query.CountAsync();

            var items = await query
                .Skip(
                    (filter.Page - 1) * filter.PageSize)
                .Take(filter.PageSize)
                .Select(p => new ProductModel
                {
                    ProductID = p.ProductID,
                    ProductName = p.ProductName,
                    Supplier = p.Supplier,
                    Category = p.Category,
                    QuantityPerUnit = p.QuantityPerUnit,
                    UnitPrice = p.UnitPrice,
                    UnitsInStock = p.UnitsInStock,
                    UnitsOnOrder = p.UnitsOnOrder,
                    ReorderLevel = p.ReorderLevel,
                    Discontinued = p.Discontinued
                })
                .ToListAsync(ct);

            var productEntities = items.Select(ProductMapper.ToEntity).ToList();

            return new PagedResult<Product>
            {
                Items = productEntities,
                Page = filter.Page,
                PageSize = filter.PageSize,
                TotalItems = totalItems
            };
        }

        public async Task<Product?> GetProductById(Guid productId, CancellationToken ct = default)
        {
            var product = await _dbContext.Products
                .AsNoTracking()
                .FirstOrDefaultAsync(p => p.ProductID == productId, ct);
            return ProductMapper.ToEntity(product);
        }

        public async Task<bool> UpdateProduct(Product product, CancellationToken ct = default)
        {
            var updatedProduct = await _dbContext.Products.FirstOrDefaultAsync(p => p.ProductID == product.ProductID, ct);
            if (updatedProduct == null)
                return false;

            updatedProduct.SupplierID = product.SupplierID;
            updatedProduct.CategoryID = product.CategoryID;
            updatedProduct.ProductName = product.ProductName;
            updatedProduct.QuantityPerUnit = product.QuantityPerUnit;
            updatedProduct.UnitPrice = product.UnitPrice;
            updatedProduct.UnitsInStock = product.UnitsInStock;
            updatedProduct.UnitsOnOrder = product.UnitsOnOrder;
            updatedProduct.ReorderLevel = product.ReorderLevel;
            updatedProduct.Discontinued = product.Discontinued;

            _dbContext.Products.Update(updatedProduct);
            var status = await _dbContext.SaveChangesAsync(ct).ContinueWith(t => t.Result > 0, ct);
            return status;
        }
    }
}
