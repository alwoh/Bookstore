using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Bookstore.Domain.Interfaces;
using Bookstore.Domain.Models;

namespace Bookstore.Domain.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;        
        private readonly IBookService _bookService;

        public CategoryService(ICategoryRepository categoryRepository, IBookService bookService)
        {
            _categoryRepository = categoryRepository;
            _bookService = bookService;
        }

        public async Task<Category> GetByIdAsync(int id)
        {
            return await _categoryRepository.GetByIdAsync(id);
        }

        public async Task<IEnumerable<Category>> GetAllAsync()
        {
            return await _categoryRepository.GetAllAsync();
        }

        //public Task<IEnumerable<Category>> FindAsync(Expression<Func<Category, bool>> predicate) => _categoryRepository.FindAsync(predicate);

        public Task AddAsync(Category category) => _categoryRepository.AddAsync(category);

        public Task UpdateAsync(Category category) => _categoryRepository.UpdateAsync(category);

        public async Task DeleteAsync(int id)
        {
            var category = await _categoryRepository.GetByIdAsync(id);
            if (category == null)
            {
            throw new KeyNotFoundException("Category not found.");
            }

            var booksWithCategory = await _bookService.GetBooksByCategory(category.Id);
            if (booksWithCategory.Any())
            {
            throw new InvalidOperationException("Cannot delete category as it is associated with existing books.");
            }

            await _categoryRepository.DeleteAsync(category.Id);
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _categoryRepository.SaveChangesAsync();
        }

        public void Dispose() => GC.SuppressFinalize(this);
        
        public async Task<IEnumerable<Category>> FindAsync(string categoryName)
        {
            return await _categoryRepository.FindAsync(c => c.Name.Contains(categoryName));
        }

    }
}