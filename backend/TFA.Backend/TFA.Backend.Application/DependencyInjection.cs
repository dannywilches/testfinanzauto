using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using TFA.Backend.Application.Commands.Auth;
using TFA.Backend.Application.Commands.CategoryCommand.CreateCategory;
using TFA.Backend.Application.Commands.CategoryCommand.DeleteCategory;
using TFA.Backend.Application.Commands.ProductCommand.BulkCreateProduct;
using TFA.Backend.Application.Commands.ProductCommand.CreateProduct;
using TFA.Backend.Application.Commands.ProductCommand.DeleteProduct;
using TFA.Backend.Application.Commands.ProductCommand.UpdateProduct;
using TFA.Backend.Application.Interfaces.Auth;
using TFA.Backend.Application.Interfaces.Category;
using TFA.Backend.Application.Interfaces.Product;
using TFA.Backend.Application.Interfaces.Services;
using TFA.Backend.Application.Interfaces.Supplier;
using TFA.Backend.Application.Queries.CategoryQuery;
using TFA.Backend.Application.Queries.ProductDetailQuery;
using TFA.Backend.Application.Queries.ProductQuery;
using TFA.Backend.Application.Queries.SupplierQuery;
using TFA.Backend.Application.Services;

namespace TFA.Backend.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            // Commands
            services.AddScoped<ILoginCommandHandler, LoginCommandHandler>();
            services.AddScoped<ICreateCategoryHandler, CreateCategoryHandler>();
            services.AddScoped<IDeleteCategoryHandler, DeleteCategoryHandler>();
            services.AddScoped<IUpdateProductHandler, UpdateProductHandler>();
            services.AddScoped<ICreateProductHandler, CreateProductHandler>();
            services.AddScoped<IDeleteProductHandler, DeleteProductHandler>();
            services.AddScoped<IBulkCreateProductsHandler, BulkCreateProductsHandler>();

            // Queries
            services.AddScoped<IProductQueryHandler, ProductQueryHandler>();
            services.AddScoped<IProductDetailQueryHandler, ProductDetailQueryHandler>();
            services.AddScoped<ICategoryQueryHandler, CategoryQueryHandler>();
            services.AddScoped<ISupplierQueryHandler, SupplierQueryHandler>();

            // Add other application services here
            services.AddScoped<IProductGeneratorService, ProductGeneratorService>();
            services.AddScoped<PasswordHasher<string>>();

            return services;
        }
    }
}
