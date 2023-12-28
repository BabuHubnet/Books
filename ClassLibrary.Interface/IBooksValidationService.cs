using ClassLibrary.DTOs;
using ClassLibrary.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ClassLibrary.Interface
{
    public interface IBooksValidationService
    {
        Task<IEnumerable<BookModel>> ValidateAndGetBookListAsync();
        Task ValidateBookInput(IEnumerable<BookInputDTO> UpdateBookDetailsRequest);
    }
}
