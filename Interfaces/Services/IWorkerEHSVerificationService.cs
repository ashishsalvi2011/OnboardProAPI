using OnboardPro.Models;

namespace OnboardPro.Interfaces.Services
{
    public interface IWorkerEHSVerificationService
    {
        Task<List<EHSVerificationPendingDto>> GetWorkersReadyForEHSVerificationAsync();
        Task<int> SaveEHSVerificationAsync(EHSVerificationSaveDto dto);
    }
}
