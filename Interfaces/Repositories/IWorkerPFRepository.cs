using OnboardPro.Models;

namespace OnboardPro.Interfaces.Repositories
{
    public interface IWorkerPFRepository
    {
        Task<List<WorkerPFDto>> GetWorkersDeatilsForPFAsync(int userId);
        Task<int> SavePFAsync(WorkerPfEsiUpsertDto dto);
    }
}
