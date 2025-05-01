using System.ComponentModel.DataAnnotations;

namespace Bookstore.API.Dtos.Category
{
    public class EditCategoryDto
    {
        [Required(ErrorMessage = "Id is required.")]
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required.")]
        [StringLength(100, ErrorMessage = "Name cannot exceed 100 characters.")]
        public string Name { get; set; }
    }
}