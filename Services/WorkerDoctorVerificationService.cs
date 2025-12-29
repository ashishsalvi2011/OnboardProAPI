using OnboardPro.Interfaces.Repositories;
using OnboardPro.Interfaces.Services;
using OnboardPro.Models;

namespace OnboardPro.Services
{
    public class WorkerDoctorVerificationService : IWorkerDoctorVerificationService
    {
        private readonly IWorkerDoctorVerificationRepository _repository;
        public WorkerDoctorVerificationService(IWorkerDoctorVerificationRepository repository)
        {
            _repository = repository;
        }
        public async Task<List<QuestionDto>> GetAllQuestions()
        {
            return await _repository.GetAllQuestions();
        }
        public async Task<List<WorkerDoctorVerificationDto>> GetWorkersReadyForDoctorVerificationAsync()
        {
            return await _repository.GetWorkersReadyForDoctorVerificationAsync();
        }
        public async Task<int> SaveDoctorVerificationAsync(DoctorVerificationRequestDto dto)
        {
            return await _repository.SaveDoctorVerificationAsync(dto);
        }
    }
}
