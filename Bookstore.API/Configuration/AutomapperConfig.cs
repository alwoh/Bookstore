using AutoMapper;
using Bookstore.API.Dtos.Book;
using Bookstore.API.Dtos.Category;
using Bookstore.Domain.Models;

namespace Bookstore.API.Configuration
{
    public class AutomapperConfig : Profile
    {
        public AutomapperConfig()
        {
            // Book mappings
            CreateMap<Book, AddBookDto>().ReverseMap();
            CreateMap<Book, EditBookDto>().ReverseMap();
            CreateMap<Book, ResultBookDto>().ReverseMap();

            // Category mappings
            CreateMap<Category, AddCategoryDto>().ReverseMap();
            CreateMap<Category, EditCategoryDto>().ReverseMap();
            CreateMap<Category, ResultCategoryDto>().ReverseMap();
        }
    }
}