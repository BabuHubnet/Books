using System;

namespace ClassLibrary.Models
{
    public class BookContentsModel
    {
        public Guid BookId { get; set; } = default;
        public int ContentOrder { get; set; } = default;
        public string ContentTitle { get; set; } = default;
        public string ContentTitleUrl { get; set; } = default;
        public string PageRange { get; set; } = default;
    }
}
