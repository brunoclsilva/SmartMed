using Moq;
using SmartMed.Test.MockData;
using Xunit;
using SmartMed.Infra.Repositories;
using SmartMed.Service.Services;
using SmartMed.Domain.Entities;

namespace SmartMed.Test.System.Services
{
    public class TestMedicationService
    {
        [Fact]
        public async Task GetAsync_ReturnMedicationCollection()
        {
            var medicationRepository = new Mock<IMedicationRepository>();
            medicationRepository.Setup(s => s.GetAsync()).ReturnsAsync(MedicationMockData.Get());
            var service = new MedicationService(medicationRepository.Object);

            var result = (List<Medication>)await service.GetAsync();

            Assert.IsType<List<Medication>>(result);
        }
    }
}
