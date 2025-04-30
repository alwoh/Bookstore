using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Bookstore.Domain.Interfaces;
using Bookstore.Domain.Models;

namespace Bookstore.Domain.Services
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _bookRepository;

        public BookService(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public async Task<Book> GetByIdAsync(int id)
        {
            return await _bookRepository.GetByIdAsync(id);
        }

        public async Task<IEnumerable<Book>> GetAllAsync()
        {
            return await _bookRepository.GetAllAsync();
        }

        public async Task AddAsync(Book book)
        {
            var existingBook = await _bookRepository.FindAsync(b => b.Name == book.Name);
            if (existingBook.Any())
            {
                throw new InvalidOperationException("A book with the same name already exists.");
            }

            await _bookRepository.AddAsync(book);
        }

        public async Task UpdateAsync(Book book)
        {
            var existingBook = await _bookRepository.FindAsync(b => b.Name == book.Name && b.Id != book.Id);
            if (existingBook.Any())
            {
                throw new InvalidOperationException("A book with the same name already exists.");
            }

            await _bookRepository.UpdateAsync(book);
        }

        public async Task DeleteAsync(int id)
        {
            await _bookRepository.DeleteAsync(id);
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _bookRepository.SaveChangesAsync();
        }

        public async Task<IEnumerable<Book>> GetBooksByCategory(int categoryId)
        {
            return await _bookRepository.GetBooksByCategory(categoryId);
        }

        public async Task<IEnumerable<Book>> SearchBookWithCategory(string searchedValue)
        {
            return await _bookRepository.SearchBookWithCategory(searchedValue);
        }

        public void Dispose() => GC.SuppressFinalize(this);

        public async Task<IEnumerable<Book>> FindAsync(string bookName)
        {
            return await _bookRepository.FindAsync(c => c.Name.Contains(bookName));
        }
    }
}