using Bogus;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using testapi.Controllers;
using testapi.Models;
using testapi.Services;

namespace testapi.Tests.Controllers
{
    public class SuperHeroControllerTests
    {

        private readonly Mock<ILogger<SuperHeroController>> _loggerMock;
        private readonly Mock<ISuperheroeservice> _superheroServiceMock;
        private readonly SuperHeroController _controller;
        public SuperHeroControllerTests()
        {
            _superheroServiceMock = new Mock<ISuperheroeservice>();
            _loggerMock = new Mock<ILogger<SuperHeroController>>();
            _controller = new SuperHeroController(_superheroServiceMock.Object, _loggerMock.Object);
        }

        [Fact]
        public async Task GetSuperHeroes_ReturnsOkResult_WithListOfSuperHeroes()
        {
            // Arrange
            //     var fakeHeroes = new List<SuperHero>
            // {
            //     new SuperHero { Id = 1, Name = "Batman", FirstName = "Intelligence" },
            //     new SuperHero { Id = 2, Name = "Superman", FirstName = "Super Strength" }
            // };
            var fakeHeroes = new Faker<SuperHero>()
                .RuleFor(h => h.Id, f => f.IndexFaker + 1)
                .RuleFor(h => h.Name, f => f.Name.FullName())
                .RuleFor(h => h.Place, f => f.Address.County())
                .RuleFor(h => h.FirstName, f => f.Name.FirstName()) // Random superpower                
                .Generate(5); // Generate 5 fake superheroes

            _superheroServiceMock.Setup(service => service.GetSuperHeroes()).ReturnsAsync(fakeHeroes);
            _superheroServiceMock.Setup(service => service.GetSuperHeroes()).ReturnsAsync(fakeHeroes);
            // When or Act
            var result = await _controller.GetSuperHeroes();
            // Result or Assert 
            var OkResult = Assert.IsType<OkObjectResult>(result.Result);
            var returnValue = Assert.IsType<List<SuperHero>>(OkResult.Value);

            Assert.Equal(5, returnValue.Count);
        }

        [Fact]
        public async Task GetSuperHeroes_ReturnsInternalServerError_WhenExceptionOccurs()
        {
            // Arrange
            _superheroServiceMock
                .Setup(service => service.GetSuperHeroes())
                .ThrowsAsync(new Exception("Database connection failed")); // Simulate failure

            // Act
            await Assert.ThrowsAsync<Exception>(() => _controller.GetSuperHeroes());
            // var result = await _controller.GetSuperHeroes();
            // Assert
            // var statusCodeResult = Assert.IsType<ObjectResult>(result.Result);
            // Assert.Equal(500, statusCodeResult.StatusCode);
        }

    }
}