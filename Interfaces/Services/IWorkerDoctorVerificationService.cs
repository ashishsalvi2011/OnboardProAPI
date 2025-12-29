using OnboardPro.Models;

namespace OnboardPro.Interfaces.Services
{
    public interface IWorkerDoctorVerificationService
    {
        Task<List<QuestionDto>> GetAllQuestions();
        Task<List<WorkerDoctorVerificationDto>> GetWorkersReadyForDoctorVerificationAsync();
        Task<int> SaveDoctorVerificationAsync(DoctorVerificationRequestDto dto);
    }
}
