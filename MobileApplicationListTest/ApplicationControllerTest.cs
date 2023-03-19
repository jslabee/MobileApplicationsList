using Microsoft.AspNetCore.Mvc;
using MobileApplicationsList.Controllers;
using MobileApplicationsList.Services;
using MobileApplicationsList.Services.ApiModel;
using Moq;


namespace MobileApplicationsList.Tests.Controllers
{
    public class ApplicationControllerTests
    {
        private readonly ApplicationController _controller;
        private readonly Mock<IApplicationService> _mockApplicationService;

        public ApplicationControllerTests()
        {
            _mockApplicationService = new Mock<IApplicationService>();
            _controller = new ApplicationController(_mockApplicationService.Object);
        }

        [Fact]
        public async Task CreateApplication_ReturnsOkResult_WhenValidRequest()
        {
            // Arrange
            var request = new CreateApplicationRequest
            {
                Name = "Test Application",
                Image = "test.png"
            };

            _mockApplicationService.Setup(service => service.AddApplicationAsync(request)).ReturnsAsync("Application created");

            // Act
            var result = await _controller.CreateApplication(request);
    
            // Assert
            Assert.IsType<OkObjectResult>(result.Result);
            Assert.Equal("Application created", ((OkObjectResult)result.Result).Value);
        }

        [Fact]
        public async Task GetAllApplications_ReturnsOkResult_WhenValidRequest()
        {
            // Arrange
            var expectedResponse = new PageParameters<IApplicationDetailsResponse>();
            _mockApplicationService.Setup(s => s.GetAllApplications(It.IsAny<int>(), It.IsAny<int>())).ReturnsAsync(expectedResponse);

            // Act
            var result = await _controller.GetAllApplications();

            // Assert
            Assert.IsType<OkObjectResult>(result.Result);
            Assert.Equal(expectedResponse, ((OkObjectResult)result.Result).Value);
        }

        [Fact]
        public async Task GetAllApplications_ReturnsStatusCode500_WhenServiceThrowsException()
        {
            // Arrange
            _mockApplicationService.Setup(s => s.GetAllApplications(It.IsAny<int>(), It.IsAny<int>())).ThrowsAsync(new Exception());

            // Act
            var result = await _controller.GetAllApplications();

            // Assert
            Assert.IsType<StatusCodeResult>(result.Result);
            Assert.Equal(500, ((StatusCodeResult)result.Result).StatusCode);
        }

    }
}
