using ClassLibrary.DTOs;
using ClassLibrary.Models;
using System.Collections.Generic;

namespace ClassLibrary.Interface
{
    public interface IBooksMapper
    {
        IEnumerable<BookDTO> MapBookListEntityToDTO(IEnumerable<BookModel> bookLists, IEnumerable<BookContentsModel> bookContentsLists);
        IEnumerable<PublisherDTO> MapPublisherListEntityToDTO(IEnumerable<PublisherModel> publisherLists);
        IEnumerable<AuthorDTO> MapAuthorListEntityToDTO(IEnumerable<AuthorModel> bookLists);
    }
}
