using OnboardPro.Models;

namespace OnboardPro.Interfaces.Services
{
    public interface IMasterService
    {
        Task<List<MasterDto>> GetMasterDataAsync(string? masterType = null);
    }
}
