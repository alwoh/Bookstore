
using System.Collections.Generic;

namespace Bookstore.Domain.Models
{
    public class Category : Entity
    {
        public string Name { get; set; }
        // EF relation
        public IEnumerable<Book> Books { get; set; }
    }
}