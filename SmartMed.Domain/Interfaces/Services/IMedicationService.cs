using SmartMed.Domain.Entities;

namespace SmartMed.Domain.Interfaces.Services
{
    public interface IMedicationService
    {
        Task<IEnumerable<Medication>> GetAsync();
        Task<bool> CreateAsync(Medication medication);
        Task<bool> DeleteAsync(Guid id);
    }
}
