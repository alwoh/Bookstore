using Bookstore.Domain.Models;

namespace Bookstore.Domain.Interfaces
{
    public interface ICategoryRepository : IRepository<Category>
    {
        // No additional methods for now        
    }
}