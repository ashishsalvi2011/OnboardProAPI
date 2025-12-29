using OnboardPro.Models;

namespace OnboardPro.Interfaces.Services
{
    public interface IWorkerDoctorVerificationService
    {
        Task<List<QuestionDto>> GetAllQuestions();
        Task<List<WorkerMedicalVerificationDto>> GetWorkersReadyForMedicalVerificationAsync();
        Task<int> SaveMedicalVerificationAsync(WorkerMedicalVerificationRequestDto dto);
    }
}
