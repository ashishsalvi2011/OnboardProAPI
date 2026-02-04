using OnboardPro.Models;

namespace OnboardPro.Interfaces.Services
{
    public interface IWorkerMedicalVerificationService
    {
        Task<List<WorkerMedicalVerificationDto>> GetWorkersReadyForMedicalVerificationAsync(int userId);
        Task<int> SaveMedicalVerificationAsync(WorkerMedicalVerificationRequestDto dto);
        Task<int> ReturnWorkerMedicalVerification(WorkerMedicalVerificationReturnDto dto);
    }
}
