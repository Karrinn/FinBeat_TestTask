using System.Data.Common;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using FinBeat_TestTask.Domain.Entities;
using FinBeat_TestTask.Infrastructure.DataBase;
using FinBeat_TestTask.Infrastructure.Repositories;

namespace FinBeat_TestTast.Tests.Infrastructure
{
    public class InMemoryItemRepositoryTest : IDisposable
    {
        private readonly DbConnection _connection;
        private readonly DbContextOptions<AppDbContext> _contextOptions;

        #region ConstructorAndDispose
        public InMemoryItemRepositoryTest()
        {

            // Create and open a connection. This creates the SQLite in-memory database, which will persist until the connection is closed
            // at the end of the test (see Dispose below).
            _connection = new SqliteConnection("Filename=:memory:");
            _connection.Open();

            // These options will be used by the context instances in this test suite, including the connection opened above.
            _contextOptions = new DbContextOptionsBuilder<AppDbContext>()
                .UseSqlite(_connection)
                .Options;

            // Create the schema and seed some data
            using var context = new AppDbContext(_contextOptions);

            if (context.Database.EnsureCreated())
            {
                using var viewCommand = context.Database.GetDbConnection().CreateCommand();
                viewCommand.CommandText = """
    CREATE TABLE Items (
        Id INTEGER PRIMARY KEY,
        Code INTEGER,
        Value TEXT
    )
    """;
                viewCommand.ExecuteNonQuery();
            }

            context.Items.AddRange(
                new Item { Id = 1, Code = 1, Value = "Test 1" },
                new Item { Id = 2, Code = 2, Value = "Test 2" },
                new Item { Id = 3, Code = 3, Value = "Test 3" });
            context.SaveChanges();
        }
        AppDbContext CreateContext() => new AppDbContext(_contextOptions);

        public void Dispose() => _connection.Dispose();
        #endregion

        [Fact]
        public void Test_Get_By_Filter()
        {
            //assert
            using var context = CreateContext();
            var repo = new ItemRepository(context);
            var filter = new ItemFilter
            {
                Code = 1
            };

            //act
            var data = repo.GetListAsync(filter, CancellationToken.None).GetAwaiter().GetResult();

            //arrange
            Assert.Equal(1, data.First().Code);
        }

        [Fact]
        public void Test_Get_All()
        {
            //assert
            using var context = CreateContext();
            var repo = new ItemRepository(context);
            var filter = new ItemFilter();

            //act
            var data = repo.GetListAsync(filter, CancellationToken.None).GetAwaiter().GetResult();

            //arrange
            Assert.Equal(3, data.Count);
        }

        [Fact]
        public void Test_SaveItem()
        {
            //assert
            using var context = CreateContext();
            var repo = new ItemRepository(context);
            var filter = new ItemFilter();

            var newItems = new List<Item> 
            {
                new Item { Id = 4, Code = 4, Value = "Test 4" }
            };

            //act
            repo.SaveAsync(newItems, CancellationToken.None).GetAwaiter().GetResult();

            var data = repo.GetListAsync(filter, CancellationToken.None).GetAwaiter().GetResult();

            //arrange
            Assert.Equal(4, data.Count);
        }

        [Fact]
        public void Test_Delete_All()
        {
            //assert
            using var context = CreateContext();
            var repo = new ItemRepository(context);
            var filter = new ItemFilter();

            //act
            repo.DeleteAllAsync(CancellationToken.None).GetAwaiter().GetResult();
            var data = repo.GetListAsync(filter, CancellationToken.None).GetAwaiter().GetResult();

            //arrange
            Assert.Equal(0, data.Count);
        }

    }
}