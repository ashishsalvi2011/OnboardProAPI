using OnboardPro.Models;

namespace OnboardPro.Interfaces.Services
{
    public interface IWorkerPFService
    {
        Task<List<WorkerPFDto>> GetWorkersDeatilsForPFAsync();
        Task<int> SavePFAsync(WorkerPfEsiUpsertDto dto);
    }
}
