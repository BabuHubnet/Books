using ClassLibrary.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ClassLibrary.Interface
{
    public interface IBooksRepository
    {
        Task<IEnumerable<BookModel>> GetBookDetailsAsync();
        Task<IEnumerable<PublisherModel>> GetPublisherDetailsAsync();
        Task<IEnumerable<BookContentsModel>> GetBookContentsAsync();
        Task<IEnumerable<AuthorModel>> GetAuthorDetailsAsync();
        Task<bool> SaveBookDetailsAsync(IEnumerable<BookModel> UpdateBookDetailsRequest);
    }
}
