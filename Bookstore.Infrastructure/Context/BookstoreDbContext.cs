using System.Linq;
using Microsoft.EntityFrameworkCore;
using Bookstore.Domain.Models;

namespace Bookstore.Infrastructure.Context
{
    public class BookstoreDbContext : DbContext
    {
        public BookstoreDbContext(DbContextOptions options)
            : base(options)
        {
        }

        public DbSet<Book> Books { get; set; }        
        public DbSet<Category> Categories { get; set; }        

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Apply character restrictions to all string properties without column types
            foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            {
                var stringProperties = entityType.ClrType.GetProperties()
                    .Where(p => p.PropertyType == typeof(string) && !p.GetCustomAttributes(false).OfType<string>().Any());

                foreach (var property in stringProperties)
                {
                    modelBuilder.Entity(entityType.ClrType)
                        .Property(property.Name)
                        .HasMaxLength(150); // Default max length for string properties
                }
            }

            // Automatically apply all configurations from the current assembly
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(BookstoreDbContext).Assembly);

            // Disable cascade delete globally
            foreach (var foreignKey in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                foreignKey.DeleteBehavior = DeleteBehavior.Restrict;
            }

            base.OnModelCreating(modelBuilder);
        }
    }
}