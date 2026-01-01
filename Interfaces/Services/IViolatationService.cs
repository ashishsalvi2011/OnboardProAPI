using OnboardPro.Models;

namespace OnboardPro.Interfaces.Services
{
    public interface IViolationService
    {
        Task<List<ViolationLevelDto>> GetViolationLevelDataAsync();
        Task<int> SaveViolationAsync(WorkerViolationUpsertDto dto);
        Task<List<WorkerViolationReasonDto>> GetViolationReasonListAsync(int? workerId);

    }
}
