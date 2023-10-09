using Flow_1Provider.data;
using Flow_1Provider.Infrastructure.Services;
using Microsoft.Azure.Cosmos;
using Moq;
using Microsoft.Extensions.Configuration;
using System.Net;

namespace Flow_1Provider.test
{
    public class ProgramTest
    {
        [Fact]
        public async Task Add_ShouldReturnTrue_WhenProgramAddedSuccessfully()
        {
            // Arrange
            var mockCosmosClient = new Mock<CosmosClient>();
            var mockConfig = new Mock<IConfiguration>();

            var programService = new ProgramService(mockCosmosClient.Object, mockConfig.Object);

            var mockContainer = new Mock<Container>();
            mockCosmosClient.Setup(c => c.GetContainer(It.IsAny<string>(), It.IsAny<string>())).Returns(mockContainer.Object);

            var mockResponse = MockResponse(true);



            var programToAdd = new Programs
            {
                id = "newProgramId",
                Description = "New Program",
                Title = "newProgramId",
                Summary = "New Program Summary",
                ApplicationClose = new DateTime(2023, 10, 8, 12, 30, 0),
                ApplicationOpen = new DateTime(2023, 10, 8, 12, 30, 0),
                Location = "Lagos",
                ProgramType = "Free",
                AppTemplate = null,
                Stages = null,
                ApplicationCriteria = null
            };


            mockContainer.Setup(c => c.CreateItemAsync<Programs>(programToAdd, null, It.IsAny<ItemRequestOptions>(), default)).ReturnsAsync((Programs program, PartitionKey? partitionKey, ItemRequestOptions requestOptions, CancellationToken cancellationToken) =>
            {
                return new Programs
                {
                    id = programToAdd.id
                };
            });



            // Act
            var result = await programService.Add(programToAdd);

            // Assert
            Assert.True(result);
        }

        // Helper method to mock iterator
        private static Mock<FeedIterator<T>> MockIterator<T>(T item)
        {
            var mockIterator = new Mock<FeedIterator<T>>();
            //mockIterator.Setup(i => i.ReadNextAsync(It.IsAny<CancellationToken>()))
            //    .ReturnsAsync(new FeedResponse<T>(new List<T> { item }));

            return mockIterator;
        }

        // Helper method to mock response
        private static Mock<ItemResponse<T>> MockResponse<T>(T resource)
        {
            var mockResponse = new Mock<ItemResponse<T>>();
            mockResponse.Setup(r => r.Resource).Returns(resource);
            return mockResponse;
        }
    
    }
}