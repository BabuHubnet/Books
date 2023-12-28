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
        public async Task<IEnumerable<PublisherModel>> GetPublisherDetailsAsync()
        {
            using (var connection = new SqlConnection(_context.ConnectionString))
            {
                return await connection.QueryAsync<PublisherModel>("SpGetPublisher", commandTimeout: _context.Timeout, commandType: CommandType.StoredProcedure);
            }
        }
        public async Task<IEnumerable<BookContentsModel>> GetBookContentsAsync()
        {
            using (var connection = new SqlConnection(_context.ConnectionString))
            {
                return await connection.QueryAsync<BookContentsModel>("SpGetBooksContents", commandTimeout: _context.Timeout, commandType: CommandType.StoredProcedure);
            }
        }
        public async Task<IEnumerable<AuthorModel>> GetAuthorDetailsAsync()
        {
            using (var connection = new SqlConnection(_context.ConnectionString))
            {
                return await connection.QueryAsync<AuthorModel>("SpGetAuthor", commandTimeout: _context.Timeout, commandType: CommandType.StoredProcedure);
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
