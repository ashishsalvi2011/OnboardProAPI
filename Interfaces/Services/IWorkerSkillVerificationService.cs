using OnboardPro.Models;

namespace OnboardPro.Interfaces.Services
{
    public interface IWorkerSkillVerificationService
    {
        Task<List<WorkerSkillVerificationDto>> GetWorkersReadyForSkillVerificationAsync(int userId);
        Task<SkillAndProficiencyResponseDto> GetSkillAndProficiencyAsync();
        Task<int> SaveSkillVerificationAsync(WorkerSkillVerificationSubmitDto dto);
        Task<int> ReturnWorkerSkillVerification(WorkerSkillVerificationReturnDto dto);
    }
}
