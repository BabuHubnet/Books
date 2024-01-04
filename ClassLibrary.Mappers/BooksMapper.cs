using ClassLibrary.DTOs;
using ClassLibrary.Interface;
using ClassLibrary.Models;
using NPOI.SS.Formula.Functions;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;

namespace ClassLibrary.Mappers
{
    public class BooksMapper : IBooksMapper
    {
        public IEnumerable<BookDTO> MapBookListEntityToDTO(IEnumerable<BookModel> bookLists, IEnumerable<BookContentsModel> bookContentsLists)
        {
            return bookLists.Select(lists => new BookDTO
            {
                Publisher = lists.Publisher,
                Title = lists.Title,
                AuthorFirstName = lists.AuthorFirstName,
                AuthorLastName = lists.AuthorLastName,
                PublicationDate = lists.PublicationDate,
                Price = lists.Price,
                BookContents = bookContentsLists.Where(g => g.BookId == lists.BookId)
                .Select(g => new BookContentsDTO
                {
                    ContentOrder = g.ContentOrder,
                    ContentTitle = g.ContentTitle.ToString(),
                    ContentTitleUrl = g.ContentTitleUrl,
                    PageRange = g.PageRange
                }).ToArray()
            });
        }
        public IEnumerable<PublisherDTO> MapPublisherListLQEntityToDTO(IEnumerable<BookModel> bookLists, IEnumerable<BookContentsModel> bookContentsLists, string sortColumn, string sortOrder)
        {
            //IEnumerable<BookModel> bookDetail = bookLists.AsQueryable();

            //Expression<Func<BookModel, object>> keySelector = sortColumn?.ToLower() switch
            //{
            //    "publisher" => BookModel => BookModel.Publisher,
            //    "author" => BookModel => BookModel.AuthorLastName + "," + BookModel.AuthorFirstName,
            //    "title" => BookModel => BookModel.Title,
            //    _ => BookModel => BookModel.BookId
            //};
            //if (sortOrder?.ToLower() == "desc")
            //{
            //    bookDetail = bookDetail.AsQueryable().OrderByDescending(n => n.Publisher);
            //}
            //else
            //{
            //    bookDetail = bookDetail.AsQueryable().OrderBy(keySelector);
            //}

            var query = from book in bookLists
                        join Content in bookContentsLists on book.BookId equals Content.BookId
                        orderby book.Publisher ascending, book.AuthorLastName + "," + book.AuthorFirstName ascending, book.Title ascending
                        select new { book.BookId, book.AuthorLastName, book.AuthorFirstName, book.Title, Content.ContentTitle, book.Publisher, book.PublicationDate, Content.PageRange };
             
            var publisher = sortOrder?.ToLower() == "desc" ? query
                .OrderByDescending(x => sortColumn?.ToLower() == "publisher" ? x.Publisher : sortColumn?.ToLower() == "author" ? x.AuthorLastName + "," + x.AuthorFirstName : sortColumn?.ToLower() == "title" ? x.Title : x.Publisher) 
                .Select(lists => new PublisherDTO
                {

                    Values = $"{lists.AuthorLastName} , {lists.AuthorFirstName} , \" { lists.Title } \" <i> { lists.ContentTitle },</i> {lists.Publisher},{lists.PublicationDate.ToString("yyyy") },pp. { lists.PageRange }. "
                }
            ): query
                .OrderBy(x => sortColumn?.ToLower() == "publisher" ? x.Publisher : sortColumn?.ToLower() == "author" ? x.AuthorLastName + "," + x.AuthorFirstName : sortColumn?.ToLower() == "title" ? x.Title : x.Publisher)
                .Select(lists => new PublisherDTO
                {

                    Values = $"{lists.AuthorLastName} , {lists.AuthorFirstName} , \" { lists.Title } \" <i> { lists.ContentTitle },</i> {lists.Publisher},{lists.PublicationDate.ToString("yyyy") },pp. { lists.PageRange }. "
                });

            return publisher;
        }

        public IEnumerable<AuthorDTO> MapAuthorListLQEntityToDTO(IEnumerable<BookModel> bookLists, IEnumerable<BookContentsModel> bookContentsLists, string sortColumn, string sortOrder)
        { 

            var query = from book in bookLists
                        join Content in bookContentsLists on book.BookId equals Content.BookId
                        orderby book.Publisher ascending, book.AuthorLastName + "," + book.AuthorFirstName ascending, book.Title ascending
                        select new { book.BookId, book.AuthorLastName, book.AuthorFirstName, book.Title, Content.ContentTitle, book.Publisher, book.PublicationDate, Content.PageRange };

            var author = sortOrder?.ToLower() == "desc" ? query
                .OrderByDescending(x => sortColumn?.ToLower() == "author" ? x.AuthorLastName + "," + x.AuthorFirstName : sortColumn?.ToLower() == "title" ? x.Title : x.Publisher)
                .Select(lists => new AuthorDTO
                {

                    Values = $"{lists.AuthorLastName} , {lists.AuthorFirstName} , \" { lists.Title } \" <i> { lists.ContentTitle },</i> {lists.Publisher},{lists.PublicationDate.ToString("yyyy") },pp. { lists.PageRange }. "
                }
            ) : query
                .OrderBy(x => sortColumn?.ToLower() == "author" ? x.AuthorLastName + "," + x.AuthorFirstName : sortColumn?.ToLower() == "title" ? x.Title : x.Publisher)
                .Select(lists => new AuthorDTO
                {

                    Values = $"{lists.AuthorLastName} , {lists.AuthorFirstName} , \" { lists.Title } \" <i> { lists.ContentTitle },</i> {lists.Publisher},{lists.PublicationDate.ToString("yyyy") },pp. { lists.PageRange }. "
                });

            return author;
        }

        public IEnumerable<AuthorDTO> MapAuthorListEntityToDTO(IEnumerable<AuthorModel> authorLists)
        {
            return authorLists.Select(lists => new AuthorDTO
            {
                Values = lists.Values
            });
        }
        public IEnumerable<PublisherDTO> MapPublisherListEntityToDTO(IEnumerable<PublisherModel> publisherLists)
        {
            return publisherLists.Select(lists => new PublisherDTO
            {
                Values = lists.Values,
            });
        }
    }
}
