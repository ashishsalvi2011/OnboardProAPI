using OnboardPro.Models;

namespace OnboardPro.Interfaces.Repositories
{
    public interface IFinalApprovalRepository
    {
        Task<List<WorkerFinalApprovalDto>> GetFinalApprovalReadyWorkersAsync(int userId);
        Task<int> FinalApproveWorkerAsync(FinalApproveWorkerDto dto);
    }
}
