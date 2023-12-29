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
            foreach (var item in UpdateBookDetailsRequest)
            {
                DateTime temp;
                if (item.Publisher == null || item.Publisher == string.Empty)
                {
                    throw new Exception($"Publisher  {item.Publisher} is not valid");
                }
                else if (item.AuthorFirstName == null || item.AuthorFirstName == string.Empty)
                {
                    throw new Exception($"AuthorFirstName  {item.AuthorFirstName} is not valid");
                }
                else if (item.AuthorLastName == null || item.AuthorLastName == string.Empty)
                {
                    throw new Exception($"AuthorLastName  {item.AuthorLastName} is not valid");
                }
                else if (item.Title == null || item.Title == string.Empty)
                {
                    throw new Exception($"Title  {item.Title} is not valid");
                }
                else if (item.PublicationDate == null || !DateTime.TryParse(item.PublicationDate.ToString(), out temp))
                {
                    throw new Exception($"PublicationDate  {item.PublicationDate} is not valid");
                }
                else if (item.Price <= 0)
                {
                    throw new Exception($"Price  {item.Price} is not valid");
                }
            }

             
        }
    }
}
