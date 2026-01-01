using OnboardPro.Models;

namespace OnboardPro.Interfaces.Repositories
{
    public interface IEmployeeRepository
    {
        Task<List<DraftWorkerDto>> GetDraftWorkersAsync();
        Task<int> ExitWorkerAsync(ExitWorkerDto request);
        Task<List<OnBoardWorkerDto>> GetOnBoardWorkersAsync();
        Task<List<WorkerIdCardDto>> GetWorkerIdCardAsync();
        Task<int> InsertOrUpdateWorkerRewardAsync(WorkerRewardUpsertDto dto);
    }
}
