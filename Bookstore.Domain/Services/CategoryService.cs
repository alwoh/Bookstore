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

        public async Task<Category> AddAsync(Category category)
        {
            if (_categoryRepository.FindAsync(c => c.Name == category.Name).Result.Any())
                return null;

            await _categoryRepository.AddAsync(category);
            return category;
        }

        public async Task<Category> UpdateAsync(Category category)
        {
            if (_categoryRepository.FindAsync(c => c.Name == category.Name && c.Id != category.Id).Result.Any())
                return null;

            await _categoryRepository.UpdateAsync(category);
            return category;
        }


        public async Task<bool> DeleteAsync(int id)
        {
            var category = await _categoryRepository.GetByIdAsync(id);
            if (category == null)
                return false;

            var booksWithCategory = await _bookService.GetBooksByCategory(category.Id);
            if (booksWithCategory.Any())
                return false;

            await _categoryRepository.DeleteAsync(category.Id);    
            return true;
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