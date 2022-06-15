using SmartMed.Domain.Entities;
using SmartMed.Domain.Interfaces.Services;
using SmartMed.Infra.Repositories;

namespace SmartMed.Service.Services
{
    public class MedicationService : IMedicationService
    {
        private readonly IMedicationRepository _medicationRepository;
        public MedicationService(IMedicationRepository medicationRepository)
        {
            _medicationRepository = medicationRepository;
        }

        public async Task<IEnumerable<Medication>> GetAsync()
        {
            return await _medicationRepository.GetAsync();
        }
        public async Task<bool> CreateAsync(Medication medication)
        {
            medication.CreationDate = DateTime.Now;
            return await _medicationRepository.CreateAsync(medication);
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            return await _medicationRepository.DeleteAsync(id);
        }
    }
}
