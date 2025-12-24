using OnboardPro.Interfaces.Repositories;
using OnboardPro.Interfaces.Services;
using OnboardPro.Models;

namespace OnboardPro.Services
{
    public class WorkerSkillVerificationService : IWorkerSkillVerificationService
    {
        private readonly IWorkerSkillVerificationRepository _repository;
        public WorkerSkillVerificationService(IWorkerSkillVerificationRepository repository)
        {
            _repository = repository;
        }
        public async Task<List<WorkerSkillVerificationDto>> GetWorkersReadyForSkillVerificationAsync()
        {
            return await _repository.GetWorkersReadyForSkillVerificationAsync();
        }
        public async Task<SkillAndProficiencyResponseDto> GetSkillAndProficiencyAsync()
        {
            return await _repository.GetSkillAndProficiencyAsync();
        }
        public async Task<int> SaveSkillVerificationAsync(WorkerSkillVerificationSubmitDto dto)
        {
            return await _repository.SaveSkillVerificationAsync(dto);
        }
    }
}
