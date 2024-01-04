using ClassLibrary.Interface;
using ClassLibrary.Models;
using Dapper;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;
using System.Transactions;

namespace ClassLibrary.Repositories
{
    public class BooksRepository : IBooksRepository
    {
        private readonly ISqlDb _context;
        private readonly ITransactionalAdapter _trxAdapter;

        public BooksRepository(ISqlDb context, ITransactionalAdapter trxAdapter)
        {
            _context = context;
            _trxAdapter = trxAdapter;
        }
        public async Task<IEnumerable<BookModel>> GetBookDetailsAsync()
        {
            using (var connection = new SqlConnection(_context.ConnectionString))
            {
                return await connection.QueryAsync<BookModel>("SpGetBooks", commandTimeout: _context.Timeout, commandType: CommandType.StoredProcedure);
            }
        }       
        public async Task<IEnumerable<BookContentsModel>> GetBookContentsAsync()
        {
            using (var connection = new SqlConnection(_context.ConnectionString))
            {
                return await connection.QueryAsync<BookContentsModel>("SpGetBooksContents", commandTimeout: _context.Timeout, commandType: CommandType.StoredProcedure);
            }
        }
        public async Task<IEnumerable<PublisherModel>> GetPublisherDetailsAsync(string sortColumn, string sortOrder)
        {
            using (var connection = new SqlConnection(_context.ConnectionString))
            {
                var parameters = new DynamicParameters();
                parameters.Add("@sortColumn", sortColumn);
                parameters.Add("@sortOrder", sortOrder);
                return await connection.QueryAsync<PublisherModel>("SpGetPublisher", param: parameters, commandTimeout: _context.Timeout, commandType: CommandType.StoredProcedure);
            }
        }
        public async Task<IEnumerable<PublisherModel>> GetBookDetailsLQAsync()
        {
            var sql = @"SELECT  
                AuthorFirstName + ',' + AuthorLastName + '. \""' + Title + '\"". < i >' +  Publisher +', ' 
	            + Convert(varchar,Year(PublicationDate)) + ',' + 'pp. ' + PageRange + '.' As MLA
                FROM[dbo].[Books] b WITH(NOLOCK)
                Inner join[dbo].[BooksContents] bc With(nolock) on bc.BookId = b.BookId
                Group by b.BookId,Publisher,AuthorLastName,AuthorFirstName,Title,PublicationDate,PageRange,ContentTitle";
            using (var connection = new SqlConnection(_context.ConnectionString))
            {
                return await connection.QueryAsync<PublisherModel>(sql, commandTimeout: _context.Timeout);
            }
        }
        public async Task<IEnumerable<AuthorModel>> GetAuthorDetailsAsync(string sortColumn, string sortOrder)
        {
            using (var connection = new SqlConnection(_context.ConnectionString))
            {
                var parameters = new DynamicParameters();
                parameters.Add("@sortColumn", sortColumn);
                parameters.Add("@sortOrder", sortOrder);
                return await connection.QueryAsync<AuthorModel>("SpGetAuthor", param: parameters, commandTimeout: _context.Timeout, commandType: CommandType.StoredProcedure);
            }
        }        

        public async Task<bool> SaveBookDetailsAsync(IEnumerable<BookModel> UpdateBookDetailsRequest)
        {
            using (var scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            {
                using (var connection = await _trxAdapter.EnListConnectionAsync())
                {
                    await _trxAdapter.InsertManyAsync("dbo.Books", UpdateBookDetailsRequest);
                    scope.Complete();
                }
            }
            return true;
        }

    }
}
