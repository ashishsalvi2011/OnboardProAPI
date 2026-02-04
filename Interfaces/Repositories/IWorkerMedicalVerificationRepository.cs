using OnboardPro.Models;

namespace OnboardPro.Interfaces.Repositories
{
    public interface IWorkerMedicalVerificationRepository
    {
        Task<List<WorkerMedicalVerificationDto>> GetWorkersReadyForMedicalVerificationAsync(int userId);
        Task<int> SaveMedicalVerificationAsync(WorkerMedicalVerificationRequestDto dto);
        Task<int> ReturnWorkerMedicalVerification(WorkerMedicalVerificationReturnDto dto);
    }
}
