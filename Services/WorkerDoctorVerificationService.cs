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
        public async Task<List<WorkerMedicalVerificationDto>> GetWorkersReadyForMedicalVerificationAsync()
        {
            return await _repository.GetWorkersReadyForMedicalVerificationAsync();
        }
        public async Task<int> SaveMedicalVerificationAsync(WorkerMedicalVerificationRequestDto dto)
        {
            return await _repository.SaveMedicalVerificationAsync(dto);
        }
    }
}
