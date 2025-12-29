using OnboardPro.Interfaces.Repositories;
using OnboardPro.Interfaces.Services;
using OnboardPro.Models;

namespace OnboardPro.Services
{
    public class FinalApprovalService : IFinalApprovalService
    {
        private readonly IFinalApprovalRepository _repository;

        public FinalApprovalService(IFinalApprovalRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<WorkerFinalApprovalDto>> GetFinalApprovalReadyWorkersAsync()
        {
            return await _repository.GetFinalApprovalReadyWorkersAsync();
        }

        public async Task<int> FinalApproveWorkerAsync(FinalApproveWorkerDto dto)
        {
            return await _repository.FinalApproveWorkerAsync(dto);
        }
    }
}
