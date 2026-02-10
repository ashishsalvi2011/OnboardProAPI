using OnboardPro.Models;

namespace OnboardPro.Interfaces.Services
{
    public interface IComplianceService
    {
        Task<int> SaveLicenseWithFilesAsync(ContractLabourLicenseDto dto);
        Task<int> SaveBOCWAsync(BOCWLicenseDto dto);
        Task<int> SaveInterstateMigrant(MigrantLicenseDto dto);
        Task<int> SaveFactoryLicense(FactoryLicenseDto dto);
        Task<List<WageMasterDto>> GeWagMasterDatails();

        Task<int> SaveWagesMaster(List<WageMasterDto> dto);

    }
}
 