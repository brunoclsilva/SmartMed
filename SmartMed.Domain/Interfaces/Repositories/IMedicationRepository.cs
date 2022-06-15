using SmartMed.Domain.Entities;

namespace SmartMed.Infra.Repositories
{
    public interface IMedicationRepository
    {
        Task<IEnumerable<Medication>> GetAsync();
        Task<bool> CreateAsync(Medication medication);
        Task<bool> DeleteAsync(Guid id);
    }
}
