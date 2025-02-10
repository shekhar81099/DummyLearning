
using System.Net;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using testapi.Services;
namespace testapi.Tests.Controllers
{
    public class SuperHeroControllerIntegrationTests : IClassFixture<WebApplicationFactory<Program>>
    {
        private readonly WebApplicationFactory<Program> _factory;

        public SuperHeroControllerIntegrationTests(WebApplicationFactory<Program> factory)
        {
            _factory = factory;
        }

        [Fact]
        public async Task GetSuperHeroes_ReturnsInternalServerError_WhenServiceFails()
        {
            // Arrange: Create a test server with a mocked failing service
            var mockService = new Mock<ISuperheroeservice>();
            mockService.Setup(service => service.GetSuperHeroes())
                       .ThrowsAsync(new Exception("Simulated service failure"));

            var clientFactory = _factory.WithWebHostBuilder(builder =>
            {
                builder.ConfigureServices(services =>
                {
                    // Replace the real service with our failing mock
                    services.AddSingleton(mockService.Object);
                });
            });

            var client = clientFactory.CreateClient();

            // Act: Call the API endpoint
            var response = await client.GetAsync("/api/SuperHero/GetSuperHeroes");

            // Assert: Verify that we receive a 500 status code
            Assert.Equal(HttpStatusCode.InternalServerError, response.StatusCode);
        }
    }
}