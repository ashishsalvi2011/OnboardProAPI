using OnboardPro.Models;

namespace OnboardPro.Interfaces.Services
{
    public interface IWorkerMedicalVerificationService
    {
        Task<List<WorkerMedicalVerificationDto>> GetWorkersReadyForMedicalVerificationAsync();
        Task<int> SaveMedicalVerificationAsync(WorkerMedicalVerificationRequestDto dto);
        Task<int> ReturnWorkerMedicalVerification(WorkerMedicalVerificationReturnDto dto);
    }
}
