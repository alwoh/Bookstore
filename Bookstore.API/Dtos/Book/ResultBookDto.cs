namespace Bookstore.API.Dtos.Book
{
    public class ResultBookDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Author { get; set; }
        public string Description { get; set; }
        public decimal Value { get; set; }
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public DateTime PublishDate { get; set; }
    }
}