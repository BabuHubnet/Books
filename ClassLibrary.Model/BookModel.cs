using System;

namespace ClassLibrary.Models
{
    public class BookModel
    {
        public Guid BookId { get; set; } = default;
        public string Publisher { get; set; } = default;
        public string AuthorFirstName { get; set; } = default;
        public string AuthorLastName { get; set; } = default;
        public string Title { get; set; } = default;
        public DateTime PublicationDate { get; set; } = default;
        public decimal Price { get; set; } = default;
    }
}
