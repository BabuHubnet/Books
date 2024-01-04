using ClassLibrary.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Books.Interface
{
    public interface IBookService
    {
        Task<IEnumerable<BookDTO>> GetBookDetailsAsync();
        Task<IEnumerable<PublisherDTO>> GetPublisherDetailsAsync(string sortColumn, string sortOrder);
        Task<IEnumerable<AuthorDTO>> GetAuthorDetailsAsync(string sortColumn, string sortOrder);
        Task<decimal> GetBookTotalPriceAsync();
        Task<bool> SaveBookDetailsAsync(IEnumerable<BookInputDTO> UpdateBookDetailsRequest);
        Task<IEnumerable<PublisherDTO>> GetPublisherDetailsLQAsync(string sortColumn, string sortOrder);
        Task<IEnumerable<AuthorDTO>> GetAuthorDetailsLQAsync(string sortColumn, string sortOrder);
    }
}
