using ClassLibrary.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ClassLibrary.Interface
{
    public interface IBooksService
    {
        Task<IEnumerable<BookDTO>> GetBookListAsync();
        Task<IEnumerable<PublisherDTO>> GetPublisherListAsync();
        Task<IEnumerable<AuthorDTO>> GetAuthorListAsync();
        Task<bool> SaveBookDetailsAsync(IEnumerable<BookInputDTO> UpdateBookDetailsRequest);
    }
}
