using OnboardPro.Models;

namespace OnboardPro.Interfaces.Repositories
{
    public interface IWorkerRepository
    {
        Task<int> InsertOrUpdateWorkerAsync(WorkerDto dto);
        Task<AddressSaveResponse> InsertOrUpdateWorkerAddressAsync(AddressSaveRequest dto);
        Task<ContactSaveResponse> InsertOrUpdateWorkerContactAsync(WorkerContactDto dto);
        Task<int> InsertOrUpdateWorkerBankDetailsAsync(WorkerBankDetailsDto dto);
        Task<KYCPFSaveResponse> InsertOrUpdateWorkerKYCOrPFAsync(KYCPFSaveRequest dto);
        Task<WorkerDetailsDto> GetWorkerFullDetail(int workerId);
    }
}
