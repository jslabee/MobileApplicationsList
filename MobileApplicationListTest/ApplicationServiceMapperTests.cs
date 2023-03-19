
using MobileApplicationsList.repository;
using MobileApplicationsList.repository.DbModel;
using MobileApplicationsList.Services.ApiModel;
using Moq;


namespace MobileApplicationsList.Services.Tests
{
    public class ApplicationServiceTests
    {
        private Mock<IApplicationbaseRepository> _mockApplicationRepository;
        private Mock<IApplicationServiceMapper> _mockApplicationServiceMapper;

        public ApplicationServiceTests()
        {
            _mockApplicationRepository = new Mock<IApplicationbaseRepository>();
            _mockApplicationServiceMapper = new Mock<IApplicationServiceMapper>();
        }


        [Theory]
        [InlineData("My Application", "myapp.png", 20.5, 4.5, 100, "https://myapp.com", "https://myapp.com", true)]
        [InlineData(null, "myapp.png", 20.5, 4.5, 100, "https://myapp.com", "https://myapp.com", false)]
        [InlineData("My Application", null, 20.5, 4.5, 100, "https://myapp.com", "https://myapp.com", false)]
        public async Task AddApplicationAsync_ShouldReturnExpectedMessage(string name, string image, double size, double score, int ratings, string androidStore, string iosStore, bool expectedSuccess)
        {
            // Arrange
            var request = new CreateApplicationRequest
            {
                Name = name,
                Image = image,
                Size = size,
                Score = score,
                Ratings = ratings,
                Android_store = androidStore,
                Ios_store = iosStore
            };

            var expectedApplication = new ApplicationBase
            {
                Id= expectedSuccess ? 1 : 0,
                Name = request.Name,
                Image = request.Image,
                platformSpecific = new System.Collections.Generic.List<AplicationDetails>
                {
                    new AplicationDetails
                    {
                        Type = ApplicationType.Android,
                        Score = request.Score,
                        Ratings = request.Ratings,
                        ApplicationStoreUrl = request.Android_store
                    },
                         new AplicationDetails {
                        Type = ApplicationType.Ios,
                        Size = request.Size,
                        Score = request.Score,
                        Ratings = request.Ratings,
                        ApplicationStoreUrl = request.Ios_store
                    }
                }
            };
 

            _mockApplicationServiceMapper.Setup(mapper => mapper.MapCreateAppRequest(request)).ReturnsAsync(expectedApplication);

            _mockApplicationRepository.Setup(repo => repo.AddAsync(expectedApplication)).ReturnsAsync(expectedApplication);

            var applicationService = new ApplicationService(_mockApplicationRepository.Object, _mockApplicationServiceMapper.Object);

            // Act
            var result = await applicationService.AddApplicationAsync(request);

            // Assert
            _mockApplicationServiceMapper.Verify(mapper => mapper.MapCreateAppRequest(request), Times.Once);
            _mockApplicationRepository.Verify(repo => repo.AddAsync(expectedApplication), Times.Once);
                
            if (expectedSuccess)
            {
                Assert.Equal("Application created Id: 1", result);
            }
            else
            {
                Assert.Equal("Error saving application", result);
            }
        }


            [Fact]
            public async Task GetAllApplications_ReturnsPageResultWithMockedData()
            {
            // Arrange
            var pageNumber = 1;
            var pageSize = 10;
            var totalCount = 20;
            var totalPages = 2;
            var applications = new List<AplicationDetails>();
            var applicationDetailsList = new List<IApplicationDetailsResponse>();

            for (int i = 0; i < totalCount; i++)
            {
                applications.Add(new Mock<AplicationDetails>().Object);
            }

            for (int i = 0; i < pageSize; i++)
            {
                applicationDetailsList.Add(new Mock<IApplicationDetailsResponse>().Object);
            }

            _mockApplicationRepository.Setup(x => x.CountAsync()).ReturnsAsync(totalCount);
            _mockApplicationRepository.Setup(x => x.ListAllPaginatedAsync(pageNumber, pageSize)).ReturnsAsync(applications);
            _mockApplicationServiceMapper.Setup(x => x.MapApplicationDetails(applications)).ReturnsAsync(applicationDetailsList);
            var applicationService = new ApplicationService(_mockApplicationRepository.Object, _mockApplicationServiceMapper.Object);

            // Act
            var result = await applicationService.GetAllApplications(pageNumber, pageSize);


            // Assert
            Assert.NotNull(result);
                Assert.Equal(totalPages, result.maxpages);
                Assert.Equal(pageNumber, result.PageNumber);
                Assert.Equal(pageSize, result.PageSize);
                Assert.Equal(applicationDetailsList, result.Items);

            }
        }


    }

