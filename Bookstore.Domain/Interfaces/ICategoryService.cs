using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Bookstore.Domain.Models;

namespace Bookstore.Domain.Interfaces
{
    public interface ICategoryService : IDisposable
    {
        Task<IEnumerable<Category>> GetAllAsync();
        Task<Category> GetByIdAsync(int id);
        Task<IEnumerable<Category>> FindAsync(string categoryName);
        Task AddAsync(Category category);
        Task UpdateAsync(Category category);
        Task DeleteAsync(int id);
        Task<int> SaveChangesAsync();        
    }
}