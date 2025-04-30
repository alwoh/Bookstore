using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Bookstore.Domain.Models;

namespace Bookstore.Domain.Interfaces
{
    public interface IBookService : IDisposable
    {
        Task<Book> GetByIdAsync(int id);
        Task<IEnumerable<Book>> GetAllAsync();
        Task<IEnumerable<Book>> FindAsync(string bookName);
        Task AddAsync(Book book);
        Task UpdateAsync(Book book);
        Task DeleteAsync(int id);
        Task<int> SaveChangesAsync();
        Task<IEnumerable<Book>> GetBooksByCategory(int categoryId);        
        Task<IEnumerable<Book>> SearchBookWithCategory(string searchedValue);
    }
}