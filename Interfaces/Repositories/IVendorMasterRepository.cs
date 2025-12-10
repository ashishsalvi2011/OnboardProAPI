using OnboardPro.Models;

namespace OnboardPro.Interfaces.Repositories
{
    public interface IVendorMasterRepository
    {
        Task<int> InsertOrUpdateVendorAsync(VendorMasterDto vendor);
        Task<List<VendorResponseDto>> GetVendorAsync();
    }
}
