using OnboardPro.Interfaces.Repositories;
using OnboardPro.Interfaces.Services;
using OnboardPro.Models;

namespace OnboardPro.Services
{
    public class WorkerEHSVerificationService : IWorkerEHSVerificationService
    {
        private readonly IWorkerEHSVerificationRepository _repository;
        public WorkerEHSVerificationService(IWorkerEHSVerificationRepository repository)
        {
            _repository = repository;
        }
        public async Task<List<EHSVerificationPendingDto>> GetWorkersReadyForEHSVerificationAsync(int userId)
        {
            return await _repository.GetWorkersReadyForEHSVerificationAsync(userId);
        }
        public async Task<int> SaveEHSVerificationAsync(EHSVerificationSaveDto dto)
        {
            return await _repository.SaveEHSVerificationAsync(dto);
        }
        public async Task<int> ReturnWorkerEHSVerification(WorkerEHSVerificationReturnDto dto)
        {
            return await _repository.ReturnWorkerEHSVerification(dto);
        }

        public async Task<List<WorkerHealthDto>> GetWorkerHealthDetails(int workerId)
        {
            return await _repository.GetWorkerHealthDetails(workerId);
        }
        
    }
}
