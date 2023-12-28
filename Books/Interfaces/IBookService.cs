using ClassLibrary.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Books.Interface
{
    public interface IBookService
    {
        Task<IEnumerable<BookDTO>> GetBookDetailsAsync();
        Task<IEnumerable<PublisherDTO>> GetPublisherDetailsAsync();
        Task<IEnumerable<AuthorDTO>> GetAuthorDetailsAsync();
        Task<decimal> GetBookTotalPriceAsync();
        Task<bool> SaveBookDetailsAsync(IEnumerable<BookInputDTO> UpdateBookDetailsRequest);
    }
}
