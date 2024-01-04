using ClassLibrary.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ClassLibrary.Interface
{
    public interface IBooksService
    {
        Task<IEnumerable<BookDTO>> GetBookListAsync();
        Task<IEnumerable<PublisherDTO>> GetPublisherListAsync(string sortColumn, string sortOrder);
        Task<IEnumerable<AuthorDTO>> GetAuthorListAsync(string sortColumn, string sortOrder); 
        Task<bool> SaveBookDetailsAsync(IEnumerable<BookInputDTO> UpdateBookDetailsRequest);
        Task<IEnumerable<PublisherDTO>> GetPublisherDetailsLQAsync(string sortColumn, string sortOrder);
        Task<IEnumerable<AuthorDTO>> GetAuthorDetailsLQAsync(string sortColumn, string sortOrder);
    }
}
