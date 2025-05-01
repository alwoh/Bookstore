using Microsoft.Extensions.DependencyInjection;
using Bookstore.Domain.Interfaces;
using Bookstore.Domain.Services;
using Bookstore.Infrastructure.Repositories;
using Bookstore.Infrastructure.Context;

namespace Bookstore.API.Configuration
{
    public static class DependencyInjectionConfig
    {
        public static IServiceCollection ResolveDependencies(this IServiceCollection services)
        {
            services.AddScoped<BookstoreDbContext>();

            // Register services
            services.AddScoped<IBookService, BookService>();
            services.AddScoped<ICategoryService, CategoryService>();

            // Register repositories
            services.AddScoped<IBookRepository, BookRepository>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();

            return services;
        }
    }
}