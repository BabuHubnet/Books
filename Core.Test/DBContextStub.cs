using ClassLibrary.Interface;
using System;

namespace Core.Test
{
    internal class DBContextStub : ISqlDb
    {
        public string ConnectionString => Environment.ExpandEnvironmentVariables("BookStore");
        public int Timeout => 0;
    }
}