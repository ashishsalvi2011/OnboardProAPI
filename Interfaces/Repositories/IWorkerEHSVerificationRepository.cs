using OnboardPro.Models;

namespace OnboardPro.Interfaces.Repositories
{
    public interface IWorkerEHSVerificationRepository
    {
        Task<List<EHSVerificationPendingDto>> GetWorkersReadyForEHSVerificationAsync(int userId);
        Task<int> SaveEHSVerificationAsync(EHSVerificationSaveDto dto);
        Task<int> ReturnWorkerEHSVerification(WorkerEHSVerificationReturnDto dto);
    }
}
