using OnboardPro.Models;

namespace OnboardPro.Interfaces.Repositories
{
    public interface ISkillMasterRepository
    {
        Task<SkillMasterResponse> GetSkillMasterDataAsync();
        Task<int> InsertOrUpdateSkillAsync(SkillDto skill);
        Task<List<SkillResponseDto>> GetAllSkillsAsync();
    }
}
