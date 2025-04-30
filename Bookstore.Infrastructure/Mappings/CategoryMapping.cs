using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Bookstore.Domain.Models;

namespace Bookstore.Infrastructure.Mappings
{
    // This class configures the Category entity using Fluent API.
    // It defines the table structure, relationships, and constraints.
    public class CategoryMapping : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            // Define the primary key for the Category entity.
            builder.HasKey(c => c.Id);

            // Ensure all string properties have character restrictions
            builder.Property(c => c.Name)
                .IsRequired()
                .HasMaxLength(100);

            // Define the relationship between Category and Book entities.
            builder.HasMany(c => c.Books)
                .WithOne(b => b.Category)
                .HasForeignKey(b => b.CategoryId);

            // Map the Category entity to the "Categories" table.
            builder.ToTable("Categories");
        }
    }
}