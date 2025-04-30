
using System;

namespace Bookstore.Domain.Models
{
    public class Book : Entity
    {
        public string Name { get; set; }
        public string Author { get; set; }
        public string Description { get; set; }
        public decimal Value { get; set; }
        public DateTime PublishDate { get; set; }
        public int CategoryId { get; set; }

        // EF relation
        public Category Category { get; set; }
    }
}
