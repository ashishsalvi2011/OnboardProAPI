using OnboardPro.Interfaces.Repositories;
using OnboardPro.Interfaces.Services;
using OnboardPro.Models;
using OnboardPro.Repositories;

namespace OnboardPro.Services
{
    public class ViolationService : IViolationService
    {
        private readonly IViolationRepository _violationRepo;

        public ViolationService(IViolationRepository violationRepo)
        {
            _violationRepo = violationRepo;
        }
        public async Task<List<ViolationLevelDto>> GetViolationLevelDataAsync()
        {
            return await _violationRepo.GetViolationLevelDataAsync();
        }
        public async Task<int> SaveViolationAsync(WorkerViolationUpsertDto dto)
        {
            return await _violationRepo.SaveViolationAsync(dto);
        }
        public Task<List<WorkerViolationReasonDto>> GetViolationReasonListAsync(int? workerId)
        {
            return _violationRepo.GetViolationReasonListAsync(workerId);
        }
    }
}
