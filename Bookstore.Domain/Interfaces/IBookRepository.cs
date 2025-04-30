using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Bookstore.Domain.Models;

namespace Bookstore.Domain.Interfaces
{
    public interface IBookRepository : IRepository<Book>
    {
        // Only include GetById and GetAll methods from IRepository
        new Task<Book> GetByIdAsync(int id);
        new Task<IEnumerable<Book>> GetAllAsync();
        Task<IEnumerable<Book>> GetBooksByCategory(int categoryId);        
        Task<IEnumerable<Book>> SearchBookWithCategory(string searchedValue);
    }
}