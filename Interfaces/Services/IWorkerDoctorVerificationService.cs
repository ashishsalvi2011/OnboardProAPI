using OnboardPro.Models;

namespace OnboardPro.Interfaces.Services
{
    public interface IWorkerDoctorVerificationService
    {
        Task<List<QuestionDto>> GetAllQuestions();
        Task<List<WorkerDoctorVerificationDto>> GetWorkersReadyForDoctorVerificationAsync(int userId);
        Task<int> SaveDoctorVerificationAsync(DoctorVerificationRequestDto dto);
        Task<int> ReturnWorkerDoctorVerification(WorkerDoctorVerificationReturnDto dto);
    }
}
