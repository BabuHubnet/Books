using ClassLibrary.Interface;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Threading.Tasks;

namespace ClassLibrary.Repositories
{
    public class AbstractTransactionalAdapter : ITransactionalAdapter
    {
        private ISqlDb _dB;
        private SqlConnection _connection;

        public AbstractTransactionalAdapter(ISqlDb dB)
        {
            _dB = dB;
        }
        public async Task<DbConnection> EnListConnectionAsync()
        {
            _connection = new SqlConnection(_dB.ConnectionString);
            await _connection.OpenAsync();
            return _connection;
        }
        public async Task<IEnumerable<T>> InsertAsync<T, P>(string target, IEnumerable<T> model, Expression<Func<T, P>> key)
        {
            var properties = typeof(T).GetProperties();
            var keyProperty = GetKeyPropertyInfo(key);
            var keyName = keyProperty.Name;

            var sql = $@"
                   DECLARE @KeyVariable TABLE ([{keyName}] UNIQUEIDENTIFIER);

                   INSERT INTO {target} ({string.Join(',', properties.Select(p => $"[{p.Name}]"))})
                   OUTPUT inserted.[{keyName}] INTO @KeyVariable
                   VALUES ({string.Join(',', properties.Select(p => $"@{p.Name}"))})

                   SELECT TOP 1 [{keyName}] FROM @KeyVariable;
                ";

            foreach (var item in model)
            {
                var keyValue = await _connection.QuerySingleAsync<int>(sql: sql, param: item, commandTimeout: _dB.Timeout);

                keyProperty.SetValue(item, keyValue);
            }

            return model;
        }

        public async Task<IEnumerable<T>> InsertManyAsync<T>(string target, IEnumerable<T> model)
        {
            var properties = typeof(T).GetProperties();

            var sql = $@" 
                   INSERT INTO {target} ({string.Join(',', properties.Select(p => $"[{p.Name}]"))})  
                   VALUES ({string.Join(',', properties.Select(p => $"@{p.Name}"))}); 
                ";

            foreach (var item in model)
            {
                await _connection.ExecuteAsync(sql: sql, param: item, commandTimeout: _dB.Timeout);
            }
            return model;
        }

        private PropertyInfo GetKeyPropertyInfo<T, P>(Expression<Func<T, P>> key)
        {
            MemberExpression member = key.Body as MemberExpression;
            if (member == null)
            {
                throw new ArgumentException($"Expression '{key}' refers to a methos, not a property.");
            }
            return member.Member as PropertyInfo;
        }

    }
}
