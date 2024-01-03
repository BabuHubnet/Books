using ClassLibrary.Repositories;
using Core.Test;
using System.Threading.Tasks;
using Xunit;

namespace Core.Tests
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

        [Fact]
        public async Task CanGetPublisherDetailsAsync()
        {
            var repository = Arrange();
            var result = await repository.GetPublisherDetailsAsync();
            Assert.NotNull(result);
        }

        [Fact]
        public async Task CanGetAuthorListAsync()
        {
            var repository = Arrange();
            var result = await repository.GetAuthorDetailsAsync();
            Assert.NotNull(result);
        }
    }
}
