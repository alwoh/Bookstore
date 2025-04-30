using Bookstore.Domain.Models;

namespace Bookstore.Domain.Interfaces
{
    public interface ICategoryRepository : IRepository<Category>
    {
        Task DeleteAsync(int id);
    }
}