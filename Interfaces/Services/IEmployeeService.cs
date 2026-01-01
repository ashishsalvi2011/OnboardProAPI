using OnboardPro.Models;

namespace OnboardPro.Interfaces.Services
{
    public interface IEmployeeService
    {
        Task<List<DraftWorkerDto>> GetDraftWorkersAsync();
        Task<int> ExitWorkerAsync(ExitWorkerDto request);
        Task<List<OnBoardWorkerDto>> GetOnBoardWorkersAsync();
        Task<List<WorkerIdCardDto>> GetIdCardDetails();
        Task<int> InsertOrUpdateRewardAsync(WorkerRewardUpsertDto dto);

    }
}
