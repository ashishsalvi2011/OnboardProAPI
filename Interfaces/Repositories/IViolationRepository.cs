using OnboardPro.Models;

namespace OnboardPro.Interfaces.Repositories
{
    public interface IViolationRepository
    {
        Task<List<ViolationLevelDto>> GetViolationLevelDataAsync();
        Task<int> SaveViolationAsync(WorkerViolationUpsertDto dto);
        Task<List<WorkerViolationReasonDto>> GetViolationReasonListAsync(int? workerId);
    }
}
