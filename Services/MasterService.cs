using OnboardPro.Interfaces.Repositories;
using OnboardPro.Interfaces.Services;
using OnboardPro.Models;
using OnboardPro.Repositories;

namespace OnboardPro.Services
{
    public class MasterService : IMasterService
    {
        private readonly IMasterRepository _masterRepo;

        public MasterService(IMasterRepository masterRepo)
        {
            _masterRepo = masterRepo;
        }
        public async Task<List<MasterDto>> GetMasterDataAsync(string? masterType = null)
        {
            return await _masterRepo.GetMasterDataAsync(masterType);
        }

    }
}
