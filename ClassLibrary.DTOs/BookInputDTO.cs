using System;

namespace ClassLibrary.DTOs
{
    public class BookInputDTO
    {
        public string Publisher { get; set; } = default;
        public string AuthorFirstName { get; set; } = default;
        public string AuthorLastName { get; set; } = default;
        public string Title { get; set; } = default;
        public DateTime PublicationDate { get; set; } = default;
        public decimal Price { get; set; } = default;

    }
}
