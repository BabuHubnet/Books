using System;

namespace ClassLibrary.Models
{
    public class AuthorModel
    {
        public Guid BookId { get; set; } = default;
        public string Title { get; set; } = default;
        public string AuthorFirstName { get; set; } = default;
        public string AuthorLastName { get; set; } = default;
    }
}
