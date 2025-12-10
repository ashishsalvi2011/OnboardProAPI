using OnboardPro.Models;

namespace OnboardPro.Interfaces.Services
{
    public interface IVendorMasterService
    {
        Task<int> SaveVendorAsync(VendorMasterDto vendor);
        Task<List<VendorResponseDto>> GetVendorAsync();
    }
}
