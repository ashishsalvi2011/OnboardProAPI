using OnboardPro.Models;

namespace OnboardPro.Interfaces.Services
{
    public interface IFinalApprovalService
    {
        Task<List<WorkerFinalApprovalDto>> GetFinalApprovalReadyWorkersAsync();
        Task<int> FinalApproveWorkerAsync(FinalApproveWorkerDto dto);
    }
}
