using OnboardPro.Models;

namespace OnboardPro.Interfaces.Repositories
{
    public interface IMasterRepository
    {
        Task<List<MasterDto>> GetMasterDataAsync(string? masterType = null);
    }
}
