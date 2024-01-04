using ClassLibrary.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ClassLibrary.Interface
{
    public interface IBooksRepository
    {
        Task<IEnumerable<BookModel>> GetBookDetailsAsync();
        Task<IEnumerable<PublisherModel>> GetPublisherDetailsAsync(string sortColumn, string sortOrder);
        Task<IEnumerable<PublisherModel>> GetBookDetailsLQAsync();
        Task<IEnumerable<BookContentsModel>> GetBookContentsAsync();
        Task<IEnumerable<AuthorModel>> GetAuthorDetailsAsync(string sortColumn, string sortOrder); 
        Task<bool> SaveBookDetailsAsync(IEnumerable<BookModel> UpdateBookDetailsRequest);
    }
}
