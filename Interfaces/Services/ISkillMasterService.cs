using OnboardPro.Models;

namespace OnboardPro.Interfaces.Services
{
    public interface ISkillMasterService
    {
        Task<SkillMasterResponse> GetAllSkillMasterDataAsync();
        Task<int> SaveSkillAsync(SkillDto skill);
        Task<List<SkillResponseDto>> GetSkillsAsync();
       
    }
}
