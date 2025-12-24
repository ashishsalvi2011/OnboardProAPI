using OnboardPro.Interfaces.Repositories;
using OnboardPro.Interfaces.Services;
using OnboardPro.Models;

namespace OnboardPro.Services
{
    public class WorkerMedicalVerificationService : IWorkerMedicalVerificationService
    {
        private readonly IWorkerMedicalVerificationRepository _repository;
        public WorkerMedicalVerificationService(IWorkerMedicalVerificationRepository repository)
        {
            _repository = repository;
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
