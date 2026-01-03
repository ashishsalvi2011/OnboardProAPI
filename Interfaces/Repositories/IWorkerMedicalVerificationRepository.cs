using OnboardPro.Models;

namespace OnboardPro.Interfaces.Repositories
{
    public interface IWorkerMedicalVerificationRepository
    {
        Task<List<WorkerMedicalVerificationDto>> GetWorkersReadyForMedicalVerificationAsync();
        Task<int> SaveMedicalVerificationAsync(WorkerMedicalVerificationRequestDto dto);
        Task<int> ReturnWorkerMedicalVerification(WorkerMedicalVerificationReturnDto dto);
    }
}
