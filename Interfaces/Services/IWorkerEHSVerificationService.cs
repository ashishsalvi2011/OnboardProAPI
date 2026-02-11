using OnboardPro.Models;

namespace OnboardPro.Interfaces.Services
{
    public interface IWorkerEHSVerificationService
    {
        Task<List<EHSVerificationPendingDto>> GetWorkersReadyForEHSVerificationAsync(int userId);
        Task<int> SaveEHSVerificationAsync(EHSVerificationSaveDto dto);
        Task<int> ReturnWorkerEHSVerification(WorkerEHSVerificationReturnDto dto);
        Task<List<WorkerHealthDto>> GetWorkerHealthDetails(int workerId);
    }
}
