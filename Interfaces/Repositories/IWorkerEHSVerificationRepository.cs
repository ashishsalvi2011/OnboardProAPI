using OnboardPro.Models;

namespace OnboardPro.Interfaces.Repositories
{
    public interface IWorkerEHSVerificationRepository
    {
        Task<List<EHSVerificationPendingDto>> GetWorkersReadyForEHSVerificationAsync();
        Task<int> SaveEHSVerificationAsync(EHSVerificationSaveDto dto);
        Task<int> ReturnWorkerEHSVerification(WorkerEHSVerificationReturnDto dto);
    }
}
