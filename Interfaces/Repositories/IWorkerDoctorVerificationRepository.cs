using OnboardPro.Models;

namespace OnboardPro.Interfaces.Repositories
{
    public interface IWorkerDoctorVerificationRepository
    {
        Task<List<QuestionDto>> GetAllQuestions();
        Task<List<WorkerMedicalVerificationDto>> GetWorkersReadyForMedicalVerificationAsync();
        Task<int> SaveMedicalVerificationAsync(WorkerMedicalVerificationRequestDto dto);
    }
}
