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
        Task<Category> AddAsync(Category category);
        Task<Category> UpdateAsync(Category category);
        Task<bool> DeleteAsync(int id);
        Task<int> SaveChangesAsync();        
    }
}