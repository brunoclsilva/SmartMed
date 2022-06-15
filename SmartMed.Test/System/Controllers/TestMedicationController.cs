using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using SmartMed.Api.Controllers;
using SmartMed.Domain.Interfaces.Services;
using SmartMed.Test.MockData;
using Xunit;
using FluentAssertions;

namespace SmartMed.Test.System.Controllers
{
    public class TestMedicationController
    {
        [Fact]
        public async Task GetAsync_ShouldReturn200Status()
        {
            var medicationService = new Mock<IMedicationService>();
            medicationService.Setup(s => s.GetAsync()).ReturnsAsync(MedicationMockData.Get());
            var loggerMock = Mock.Of<ILogger<MedicationController>>();
            var controller = new MedicationController(loggerMock, medicationService.Object);

            var result = (OkObjectResult)await controller.GetAsync();

            result.StatusCode.Should().Be(200);
        }

        [Fact]
        public async Task CreateAsync_ShouldReturn200Status()
        {
            var medicationService = new Mock<IMedicationService>();
            var medication = MedicationMockData.GetMedication();
            medicationService.Setup(s => s.CreateAsync(medication)).ReturnsAsync(true);
            var loggerMock = Mock.Of<ILogger<MedicationController>>();
            var controller = new MedicationController(loggerMock, medicationService.Object);

            var result = (OkObjectResult)await controller.CreateAsync(medication);

            result.StatusCode.Should().Be(200);
        }

        [Fact]
        public async Task DeleteAsync_ShouldReturn200Status()
        {
            var medicationService = new Mock<IMedicationService>();
            var guid = new Guid();
            medicationService.Setup(s => s.DeleteAsync(guid)).ReturnsAsync(true);
            var loggerMock = Mock.Of<ILogger<MedicationController>>();
            var controller = new MedicationController(loggerMock, medicationService.Object);

            var result = (OkObjectResult)await controller.DeleteAsync(guid);

            result.StatusCode.Should().Be(200);
        }
    }
}
