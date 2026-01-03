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
        public async Task<List<EHSVerificationPendingDto>> GetWorkersReadyForEHSVerificationAsync()
        {
            return await _repository.GetWorkersReadyForEHSVerificationAsync();
        }
        public async Task<int> SaveEHSVerificationAsync(EHSVerificationSaveDto dto)
        {
            return await _repository.SaveEHSVerificationAsync(dto);
        }
        public async Task<int> ReturnWorkerEHSVerification(WorkerEHSVerificationReturnDto dto)
        {
            return await _repository.ReturnWorkerEHSVerification(dto);
        }
    }
}
