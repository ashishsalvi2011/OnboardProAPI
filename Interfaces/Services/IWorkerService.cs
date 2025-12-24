using OnboardPro.Models;

namespace OnboardPro.Interfaces.Services
{
    public interface IWorkerService
    {
        Task<int> InsertOrUpdateWorkerAsync(WorkerDto dto);
        Task<AddressSaveResponse> SaveWorkerAddressAsync(AddressSaveRequest dto);
        Task<ContactSaveResponse> SaveWorkerContactAsync(WorkerContactDto dto);
        Task<int> SaveWorkerBankDetailsAsync(WorkerBankDetailsDto dto);
        Task<KYCPFSaveResponse> SaveWorkerKYCOrPFAsync(KYCPFSaveRequest dto);
        Task<WorkerDetailsDto> GetWorkerById(int WorkerId);

    }
}
