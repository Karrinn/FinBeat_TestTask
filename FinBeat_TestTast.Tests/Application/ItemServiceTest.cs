using FinBeat_TestTask.Domain.Entities;
using FinBeat_TestTask.Application.Services;
using FinBeat_TestTask.Domain.Repositories;
using Moq;
using FinBeat_TestTask.Application.Requests;
using FinBeat_TestTask.Application;

namespace FinBeat_TestTast.Tests.Application
{
    public class ItemServiceTest
    {
        [Fact]
        public async Task Test_GetList()
        {
            // Arrange
            var repositoryMock = new Mock<IItemRepository>();
            repositoryMock
                .Setup(r => r.GetListAsync(It.IsAny<ItemFilter>(), CancellationToken.None))
                .ReturnsAsync(new List<Item> {
                    new Item { Id = 1, Code = 1, Value = "1" },
                    new Item { Id = 2, Code = 2, Value = "2" },
                    new Item { Id = 3, Code = 3, Value = "3" }
                });

            var itemService = new ItemService(repositoryMock.Object);
            var filter = new GetItemsRequest();

            // Act
            var data = await itemService.GetListAsync(filter, CancellationToken.None);

            // Assert
            repositoryMock.Verify(r => r.GetListAsync(It.IsAny<ItemFilter>(), CancellationToken.None), Times.Once);
            Assert.Equal(3, data.Count);
        }

        [Fact]
        public async Task Test_GetOne()
        {
            // Arrange
            var repositoryMock = new Mock<IItemRepository>();
            repositoryMock
                .Setup(r => r.GetListAsync(It.IsAny<ItemFilter>(), CancellationToken.None))
                .ReturnsAsync(new List<Item> {
                    new Item { Id = 1, Code = 1, Value = "1" },
                    new Item { Id = 2, Code = 2, Value = "2" },
                    new Item { Id = 3, Code = 3, Value = "3" }
                });

            var itemService = new ItemService(repositoryMock.Object);
            var filter = new GetItemsRequest { Code = 1 };

            // Act
            var data = await itemService.GetListAsync(filter, CancellationToken.None);

            // Assert
            repositoryMock.Verify(r => r.GetListAsync(It.IsAny<ItemFilter>(), CancellationToken.None), Times.Once);
            Assert.Equal(1, data.First().Code);
        }

    }
}
