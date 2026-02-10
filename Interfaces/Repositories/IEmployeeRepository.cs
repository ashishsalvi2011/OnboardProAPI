using OnboardPro.Models;

namespace OnboardPro.Interfaces.Repositories
{
    public interface IEmployeeRepository
    {
        Task<List<DraftWorkerDto>> GetDraftWorkersAsync(int userId);
        Task<List<OnBoardWorkerDto>> GetWorkersForExit(int userId);
        Task<int> ExitWorkerAsync(ExitWorkerDto request);
        Task<List<OnBoardWorkerDto>> GetOnBoardWorkersAsync(int userId);
        Task<List<WorkerIdCardDto>> GetWorkerIdCardAsync(int userId);
        Task<int> InsertOrUpdateWorkerRewardAsync(WorkerRewardUpsertDto dto);
        Task<int> BlockOrUnblockWorkerAsync(WorkerBlockRequestDto request);
        Task<List<ReturnedWorkerDto>> GetReturnedWorkersAsync(int userId);
        Task<int> UpdateWokerGatePassDetails(WorkerWageDto request);
    }
}
