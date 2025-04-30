using Bookstore.Domain.Interfaces;
using Bookstore.Domain.Models;
using Bookstore.Infrastructure.Context;

namespace Bookstore.Infrastructure.Repositories
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        public CategoryRepository(BookstoreDbContext context) : base(context)
        {
        }
    }
}