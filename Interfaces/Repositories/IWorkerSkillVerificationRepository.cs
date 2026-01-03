using OnboardPro.Models;

namespace OnboardPro.Interfaces.Repositories
{
    public interface IWorkerSkillVerificationRepository
    {
        Task<List<WorkerSkillVerificationDto>> GetWorkersReadyForSkillVerificationAsync();
        Task<SkillAndProficiencyResponseDto> GetSkillAndProficiencyAsync();
        Task<int> SaveSkillVerificationAsync(WorkerSkillVerificationSubmitDto dto);
        Task<int> ReturnWorkerSkillVerification(WorkerSkillVerificationReturnDto dto);
    }
}
