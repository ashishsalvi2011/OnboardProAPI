using OnboardPro.Models;

namespace OnboardPro.Interfaces.Repositories
{
    public interface IWorkerDoctorVerificationRepository
    {
        Task<List<QuestionDto>> GetAllQuestions();
        Task<List<WorkerDoctorVerificationDto>> GetWorkersReadyForDoctorVerificationAsync();
        Task<int> SaveDoctorVerificationAsync(DoctorVerificationRequestDto dto);
    }
}
