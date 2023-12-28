using ClassLibrary.Repositories;
using NUnit.Framework;
using System.Threading.Tasks;
using Xunit;

namespace Core.Test
{
    public class BooksRepositoryTest
    {
        public static BooksRepository Arrange()
        {
            return new BooksRepository(new DBContextStub(), null);
        }

        [Fact]
        public async Task CanGetBookDetailsAsync()
        {
            var repository = Arrange();
            var result = await repository.GetBookDetailsAsync();
            Assert.NotNull(result);
        }
    }
}