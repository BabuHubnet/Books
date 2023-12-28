using ClassLibrary.DTOs;
using ClassLibrary.Interface;
using ClassLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace ClassLibrary.Services
{
    public class BooksService : IBooksService
    {
        private readonly IBooksRepository _booksRepository;
        private readonly IBooksMapper _booksMapper;
        private readonly IBooksValidationService _validator;

        public BooksService(IBooksRepository booksRepository, IBooksMapper booksMapper, IBooksValidationService validator)
        {
            _booksRepository = booksRepository;
            _booksMapper = booksMapper;
            _validator = validator;
        }
        public async Task<IEnumerable<BookDTO>> GetBookListAsync()
        {
            await _validator.ValidateAndGetBookListAsync();

            var bookLites = await _booksRepository.GetBookDetailsAsync();
            var bookContents = await _booksRepository.GetBookContentsAsync();
            return _booksMapper.MapBookListEntityToDTO(bookLites, bookContents);
        }
        public async Task<IEnumerable<PublisherDTO>> GetPublisherListAsync()
        {
            await _validator.ValidateAndGetBookListAsync();

            var PublisherList = await _booksRepository.GetPublisherDetailsAsync();
            return _booksMapper.MapPublisherListEntityToDTO(PublisherList);
        }
        public async Task<IEnumerable<AuthorDTO>> GetAuthorListAsync()
        {
            await _validator.ValidateAndGetBookListAsync();

            var authorLites = await _booksRepository.GetAuthorDetailsAsync();
            return _booksMapper.MapAuthorListEntityToDTO(authorLites);
        }
        public async Task<bool> SaveBookDetailsAsync(IEnumerable<BookInputDTO> UpdateBookDetailsRequest)
        {
            var bookModel = MapBookDetailsDTOtoEntity(UpdateBookDetailsRequest);
            var authorLites = await _booksRepository.SaveBookDetailsAsync(bookModel);
            return authorLites;
        }
        public IEnumerable<BookModel> MapBookDetailsDTOtoEntity(IEnumerable<BookInputDTO> UpdateBookDetailsDTO)
        {
            return UpdateBookDetailsDTO.Select(i => new BookModel
            {
                BookId = Guid.NewGuid(),
                Title = i.Title,
                Publisher = i.Publisher,
                AuthorFirstName = i.AuthorFirstName,
                AuthorLastName = i.AuthorLastName,
                PublicationDate = i.PublicationDate,
                Price = i.Price
            });
        }
    }
}
