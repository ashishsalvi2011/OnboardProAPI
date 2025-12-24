using OnboardPro.Interfaces.Repositories;
using OnboardPro.Interfaces.Services;
using OnboardPro.Models;

namespace OnboardPro.Services
{
    public class WorkerService:IWorkerService
    {
        private readonly IWorkerRepository _workerRepository;

        public WorkerService(IWorkerRepository workerRepository)
        {
            _workerRepository = workerRepository;
        }
        public async Task<int> InsertOrUpdateWorkerAsync(WorkerDto dto)
        {
            return await _workerRepository.InsertOrUpdateWorkerAsync(dto);
        }
        public async Task<AddressSaveResponse> SaveWorkerAddressAsync(AddressSaveRequest dto)
        {
            return await _workerRepository.InsertOrUpdateWorkerAddressAsync(dto);
        }
        public async Task<ContactSaveResponse> SaveWorkerContactAsync(WorkerContactDto dto)
        {
            return await _workerRepository.InsertOrUpdateWorkerContactAsync(dto);
        }
        public async Task<int> SaveWorkerBankDetailsAsync(WorkerBankDetailsDto dto)
        {
            return await _workerRepository.InsertOrUpdateWorkerBankDetailsAsync(dto);
        }
        public async Task<KYCPFSaveResponse> SaveWorkerKYCOrPFAsync(KYCPFSaveRequest dto)
        {
            return await _workerRepository.InsertOrUpdateWorkerKYCOrPFAsync(dto);
        }
        public async Task<WorkerDetailsDto> GetWorkerById(int WorkerId) {
            return await _workerRepository.GetWorkerFullDetail(WorkerId);
        }
    }
}
