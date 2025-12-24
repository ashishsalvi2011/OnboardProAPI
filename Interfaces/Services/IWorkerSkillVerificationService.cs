using OnboardPro.Models;

namespace OnboardPro.Interfaces.Services
{
    public interface IWorkerSkillVerificationService
    {
        Task<List<WorkerSkillVerificationDto>> GetWorkersReadyForSkillVerificationAsync();
        Task<SkillAndProficiencyResponseDto> GetSkillAndProficiencyAsync();
        Task<int> SaveSkillVerificationAsync(WorkerSkillVerificationSubmitDto dto);
    }
}
