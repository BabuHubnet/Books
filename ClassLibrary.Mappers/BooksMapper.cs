using ClassLibrary.DTOs;
using ClassLibrary.Interface;
using ClassLibrary.Models;
using System.Collections.Generic;
using System.Linq;
namespace ClassLibrary.Mappers
{
    public class BooksMapper : IBooksMapper
    {
        public IEnumerable<BookDTO> MapBookListEntityToDTO(IEnumerable<BookModel> bookLists, IEnumerable<BookContentsModel> bookContentsLists)
        {
            return bookLists.Select(lists => new BookDTO
            {
                Publisher = lists.Publisher,
                Title = lists.Title,
                AuthorFirstName = lists.AuthorFirstName,
                AuthorLastName = lists.AuthorLastName,
                PublicationDate = lists.PublicationDate,
                Price = lists.Price,
                BookContents = bookContentsLists.Where(g => g.BookId == lists.BookId)
                .Select(g => new BookContentsDTO
                {
                    ContentOrder = g.ContentOrder,
                    ContentTitle = g.ContentTitle,
                    ContentTitleUrl = g.ContentTitleUrl,
                    PageRange = g.PageRange
                }).ToArray()
            });
        }
        public IEnumerable<AuthorDTO> MapAuthorListEntityToDTO(IEnumerable<AuthorModel> authorLists)
        {
            return authorLists.Select(lists => new AuthorDTO
            {
                Title = lists.Title,
                AuthorFirstName = lists.AuthorFirstName,
                AuthorLastName = lists.AuthorLastName
            });
        }
        public IEnumerable<PublisherDTO> MapPublisherListEntityToDTO(IEnumerable<PublisherModel> publisherLists)
        {
            return publisherLists.Select(lists => new PublisherDTO
            {
                Publisher = lists.Publisher,
                Title = lists.Title,
                AuthorFirstName = lists.AuthorFirstName,
                AuthorLastName = lists.AuthorLastName
            });
        }
    }
}
