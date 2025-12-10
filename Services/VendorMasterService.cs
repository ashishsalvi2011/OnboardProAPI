using OnboardPro.Interfaces.Repositories;
using OnboardPro.Interfaces.Services;
using OnboardPro.Models;

namespace OnboardPro.Services
{
    public class VendorMasterService:IVendorMasterService
    {
        private readonly IVendorMasterRepository _repo;

        public VendorMasterService(IVendorMasterRepository repo)
        {
            _repo = repo;
        }

        public async Task<int> SaveVendorAsync(VendorMasterDto vendor)
        {
            return await _repo.InsertOrUpdateVendorAsync(vendor);
        }

        public Task<List<VendorResponseDto>> GetVendorAsync() => _repo.GetVendorAsync();
    }
}
