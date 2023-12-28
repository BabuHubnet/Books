using ClassLibrary.DTOs;
using ClassLibrary.Interface;
using ClassLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace ClassLibrary.Validators
{
    public class BooksValidator : IBooksValidationService
    {
        private readonly IBooksRepository _booksRepository;

        public BooksValidator(IBooksRepository booksRepository)
        {
            _booksRepository = booksRepository;
        }
        public async Task<IEnumerable<BookModel>> ValidateAndGetBookListAsync()
        {
            var booksList = await _booksRepository.GetBookDetailsAsync();
            if (booksList == null || !booksList.Any())
            {
                throw new Exception("No Books Details");
            }
            return booksList;
        }
        public async Task ValidateBookInput(IEnumerable<BookInputDTO> UpdateBookDetailsRequest)
        {
            if (UpdateBookDetailsRequest == null || !UpdateBookDetailsRequest.Any())
            {
                throw new Exception("No Books Details Found");
            }
        }
    }
}
