using OnboardPro.Interfaces.Repositories;
using OnboardPro.Interfaces.Services;
using OnboardPro.Models;

namespace OnboardPro.Services
{
    public class SkillMasterService : ISkillMasterService
    {
        private readonly ISkillMasterRepository _repo;

        public SkillMasterService(ISkillMasterRepository repo)
        {
            _repo = repo;
        }

        public async Task<SkillMasterResponse> GetAllSkillMasterDataAsync()
        {
            return await _repo.GetSkillMasterDataAsync();
        }

        public async Task<int> SaveSkillAsync(SkillDto skill)
        {
            // Optional: add business rules here
            if (string.IsNullOrEmpty(skill.SkillName))
                throw new Exception("Skill name is required");

            return await _repo.InsertOrUpdateSkillAsync(skill);
        }

        public async Task<List<SkillResponseDto>> GetSkillsAsync()
        {
            return await _repo.GetAllSkillsAsync();
        }
    }
}
