using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ClassLibrary.Interface
{
    public interface ITransactionalAdapter
    {
        Task<DbConnection> EnListConnectionAsync();
        Task<IEnumerable<T>> InsertAsync<T, P>(string target, IEnumerable<T> model, Expression<Func<T, P>> key);

        Task<IEnumerable<T>> InsertManyAsync<T>(string target, IEnumerable<T> model);
    }
}
