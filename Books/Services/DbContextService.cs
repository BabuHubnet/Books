using ClassLibrary.Interface;
using Microsoft.Extensions.Configuration;
using System;

namespace Books.Services
{
    public class DbContext : ISqlDb
    {
        private readonly IConfiguration _configuration;

        public DbContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public string ConnectionString => Environment.ExpandEnvironmentVariables(_configuration.GetConnectionString("BookStore")!);
        public int Timeout => _configuration.GetValue<int>("ConnectionTimeout:BookStore");
    }
}
