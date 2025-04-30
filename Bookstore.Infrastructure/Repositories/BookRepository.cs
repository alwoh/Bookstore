using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Bookstore.Domain.Interfaces;
using Bookstore.Domain.Models;
using Bookstore.Infrastructure.Context;

namespace Bookstore.Infrastructure.Repositories
{
    public class BookRepository : Repository<Book>, IBookRepository
    {
        public BookRepository(BookstoreDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Book>> GetBooksByCategory(int categoryId)
        {
            return await FindAsync(b => b.CategoryId == categoryId);
        }

        public async Task<IEnumerable<Book>> SearchBookWithCategory(string searchedValue)
        {
             return await _context.Books.AsNoTracking()
                .Include(b => b.Category)
                .Where(b => b.Name.Contains(searchedValue) || 
                            b.Author.Contains(searchedValue) ||
                            b.Description.Contains(searchedValue) ||
                            b.Category.Name.Contains(searchedValue))
                .ToListAsync();
        }

        public async Task<Book> GetByIdAsync(int id)
        {
            return await _dbSet.AsNoTracking()
                .Include(b => b.Category)
                .FirstOrDefaultAsync(b => b.Id == id);
        }

        public async Task<IEnumerable<Book>> GetAllAsync()
        {
            return await _dbSet.AsNoTracking()
                .Include(b => b.Category)
                .OrderBy(b => b.Name)
                .ToListAsync();
        }
    }
}