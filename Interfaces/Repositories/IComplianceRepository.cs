using OnboardPro.Models;

namespace OnboardPro.Interfaces.Repositories
{
    public interface IComplianceRepository
    {

        Task<int> SaveLicenseWithFilesAsync(ContractLabourLicenseDto dto);
        Task<int> SaveBOCWAsync(BOCWLicenseDto dto);
        Task<int> SaveInterstateMigrantAsync(MigrantLicenseDto dto);
        Task<int> SaveFactoryLicense(FactoryLicenseDto dto);
        Task<List<WageMasterDto>> GeWagMasterDatails();
        Task<int> SaveWagesMaster(List<WageMasterDto> dto);
        
    }

}
