using OnboardPro.Models;

namespace OnboardPro.Interfaces.Services
{
    public interface IFinalApprovalService
    {
        Task<List<WorkerFinalApprovalDto>> GetFinalApprovalReadyWorkersAsync(int userId);
        Task<int> FinalApproveWorkerAsync(FinalApproveWorkerDto dto);
    }
}
