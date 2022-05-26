using Moq;
using MWNZ.Evaluation.Api.Controllers;
using MWNZ.Evaluation.Services.Interface;
using NUnit.Framework;

namespace MWNZ.Evaluation.Tests.Controllers
{
    public class CompaniesControllerTests
    {
        private CompaniesController _companiesController;
        private Mock<IMWNZCompaniesService> _MWNZCompaniesService;

        [Test]
        public async Task GetAsync_Ok()
        {
            // Arrange
            var response = new Models.CompanyReponseViewModel
            {
                Data =
                {
                    Id = 1,
                    Name = "MWNZ",
                    Description = "..is awesome"
                }
            };

            _MWNZCompaniesService = new Mock<IMWNZCompaniesService>();
            _MWNZCompaniesService.Setup(x => x.GetCompanyAsync(It.IsAny<int>()))
                .ReturnsAsync(response);

            _companiesController = new CompaniesController(_MWNZCompaniesService.Object);

            // Act
            var controllerResponse = await _companiesController.GetAsync(It.IsAny<int>());
            var responseValue = controllerResponse.Value as Models.Company;

            // Assert
            Assert.AreEqual(response.Data.Id, responseValue.Id);
            Assert.AreEqual(response.Data.Name, responseValue.Name);
            Assert.AreEqual(response.Data.Description, responseValue.Description);
        }

        [Test]
        public async Task GetAsync_NotFound()
        {
            // Arrange
            var response = new Models.CompanyReponseViewModel
            {
                Error =
                {
                    ErrorCode = "400",
                    ErrorDescription = $"Company with id '3' could not be found."
                }
            };

            _MWNZCompaniesService = new Mock<IMWNZCompaniesService>();
            _MWNZCompaniesService.Setup(x => x.GetCompanyAsync(It.IsAny<int>()))
                .ReturnsAsync(response);

            _companiesController = new CompaniesController(_MWNZCompaniesService.Object);

            // Act
            var controllerResponse = await _companiesController.GetAsync(It.IsAny<int>());
            var responseValue = controllerResponse.Value as Models.Error;

            // Assert
            Assert.AreEqual(response.Error.ErrorCode, responseValue.ErrorCode);
            Assert.AreEqual(response.Error.ErrorDescription, responseValue.ErrorDescription);
        }
    }
}