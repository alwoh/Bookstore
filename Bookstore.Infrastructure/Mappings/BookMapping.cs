using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Bookstore.Domain.Models;

// This class configures the Book entity using Fluent API.
// It defines the table structure, relationships, and constraints.
namespace Bookstore.Infrastructure.Mappings
{
    public class BookMapping : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            // Define the primary key for the Book entity.
            builder.HasKey(b => b.Id);

            // Configure the Name property with required and max length constraints.
            builder.Property(b => b.Name)
                .IsRequired()
                .HasMaxLength(200);

            // Configure the Author property with required and max length constraints.
            builder.Property(b => b.Author)
                .IsRequired()
                .HasMaxLength(100);

            // Configure the Description property with a max length constraint.
            builder.Property(b => b.Description)
                .HasMaxLength(1000);

            // Configure the Value property with a specific column type.
            builder.Property(b => b.Value)
                .HasColumnType("decimal(18,2)");

            // Define the relationship between Book and Category entities.
            builder.HasOne(b => b.Category)
                .WithMany(c => c.Books)
                .HasForeignKey(b => b.CategoryId);

            // Map the Book entity to the "Books" table.
            builder.ToTable("Books");
        }
    }
}