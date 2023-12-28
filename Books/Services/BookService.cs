using Books.Interface;
using ClassLibrary.DTOs;
using ClassLibrary.Interface;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Books.Services
{
    public class BookService : IBookService
    {
        private readonly ILogger<BookService> _logger;
        private readonly IBooksService _bookService;

        public BookService(ILogger<BookService> logger, IBooksService bookService)
        {
            _logger = logger;
            _bookService = bookService;
        }

        public async Task<IEnumerable<BookDTO>> GetBookDetailsAsync()
        {
            var result = await _bookService.GetBookListAsync();
            return result;
        }
        public async Task<IEnumerable<PublisherDTO>> GetPublisherDetailsAsync()
        {
            var result = await _bookService.GetPublisherListAsync();
            return result;
        }
        public async Task<IEnumerable<AuthorDTO>> GetAuthorDetailsAsync()
        {
            var result = await _bookService.GetAuthorListAsync();
            return result;
        }
        public async Task<decimal> GetBookTotalPriceAsync()
        {
            var result = await _bookService.GetBookListAsync();
            var totalPrice = result.GroupBy(x => x.Publisher)
                            .Select(g => g.Sum(x => x.Price)).Sum();
            return totalPrice;
        }

        public async Task<bool> SaveBookDetailsAsync(IEnumerable<BookInputDTO> UpdateBookDetailsRequest)
        {
            var result = await _bookService.SaveBookDetailsAsync(UpdateBookDetailsRequest);
            return result;
        }
    }
}
