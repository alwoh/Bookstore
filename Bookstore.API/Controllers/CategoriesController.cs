using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Bookstore.API.Dtos.Category;
using Bookstore.Domain.Interfaces;
using Bookstore.Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Bookstore.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoriesController : MainController
    {
        private readonly ICategoryService _categoryService;
        private readonly IMapper _mapper;

        public CategoriesController(ICategoryService categoryService, IMapper mapper)
        {
            _categoryService = categoryService;
            _mapper = mapper;
        }

        [HttpGet]        
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAll()
        {
            var categories = await _categoryService.GetAllAsync();
         
            return Ok(_mapper.Map<IEnumerable<ResultCategoryDto>>(categories));
        }

        [HttpGet("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetById(int id)
        {
            var category = await _categoryService.GetByIdAsync(id);

            if (category == null) return NotFound();

            return Ok(_mapper.Map<ResultCategoryDto>(category));
        }

         [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Add(AddCategoryDto categoryDto)
        {
            if (!ModelState.IsValid) return BadRequest();

            var category = _mapper.Map<Category>(categoryDto);
            var categoryResult = await _categoryService.AddAsync(category);

            if (categoryResult == null) return BadRequest();

            return Ok(_mapper.Map<ResultCategoryDto>(categoryResult));
        }

        [HttpPut("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Update(int id, EditCategoryDto categoryDto)
        {
            if (id != categoryDto.Id) return BadRequest();

            if (!ModelState.IsValid) return BadRequest();

            await _categoryService.UpdateAsync(_mapper.Map<Category>(categoryDto));

            return Ok(categoryDto);
        }

        [HttpDelete("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Remove(int id)
        {                        
            var result = await _categoryService.DeleteAsync(id);

            if (!result) return BadRequest();

            return Ok();
        }

        [HttpGet]
        [Route("search/{category}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<List<Category>>> Search(string category)
        {
            var categories = _mapper.Map<List<Category>>(await _categoryService.FindAsync(category));

            if (categories == null || categories.Count == 0)
                return NotFound("None category was founded");

            return Ok(categories);
        }    
    }
}