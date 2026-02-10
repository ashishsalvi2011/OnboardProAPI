using OnboardPro.Interfaces.Repositories;
using OnboardPro.Interfaces.Services;
using OnboardPro.Models;

namespace OnboardPro.Services
{
    public class WorkerPFService : IWorkerPFService
    {
        private readonly IWorkerPFRepository _repository;
        public WorkerPFService(IWorkerPFRepository repository)
        {
            _repository = repository;
        }
        public async Task<List<WorkerPFDto>> GetWorkersDeatilsForPFAsync(int userId)
        {
            return await _repository.GetWorkersDeatilsForPFAsync(userId);
        }
        public async Task<int> SavePFAsync(WorkerPfEsiUpsertDto dto)
        {
            return await _repository.SavePFAsync(dto);
        }
    }
}
