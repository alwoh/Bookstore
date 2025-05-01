using System.ComponentModel.DataAnnotations;

namespace Bookstore.API.Dtos.Category
{
    public class AddCategoryDto
    {
        [Required(ErrorMessage = "Name is required.")]
        [StringLength(100, ErrorMessage = "Name cannot exceed 100 characters.")]
        public string Name { get; set; }
    }
}