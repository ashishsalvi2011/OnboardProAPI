using OnboardPro.Interfaces.Repositories;
using OnboardPro.Interfaces.Services;
using OnboardPro.Models;

namespace OnboardPro.Services
{
    public class ComplianceService : IComplianceService
    {
        private readonly IComplianceRepository _complianceRepository;
        public ComplianceService(IComplianceRepository complianceRepository)
        {
            _complianceRepository = complianceRepository;
        }
        public async Task<int> SaveLicenseWithFilesAsync(ContractLabourLicenseDto request)
        {
            return await _complianceRepository.SaveLicenseWithFilesAsync(request);
        }
        public async Task<int> SaveBOCWAsync(BOCWLicenseDto request)
        {
            return await _complianceRepository.SaveBOCWAsync(request);
        }
        public async Task<int> SaveInterstateMigrant(MigrantLicenseDto request)
        {
            return await _complianceRepository.SaveInterstateMigrantAsync(request);
        }
        public async Task<int> SaveFactoryLicense(FactoryLicenseDto request)
        {
            return await _complianceRepository.SaveFactoryLicense(request);
        }
        public async Task<List<WageMasterDto>> GeWagMasterDatails()
        {
            return await _complianceRepository.GeWagMasterDatails();
        }
        public async Task<int> SaveWagesMaster(List<WageMasterDto> request)
        {
            return await _complianceRepository.SaveWagesMaster(request);
        }

    }
}
