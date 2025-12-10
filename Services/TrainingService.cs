using OnboardPro.Interfaces.Repositories;
using OnboardPro.Interfaces.Services;
using OnboardPro.Models;

namespace OnboardPro.Services
{
    public class TrainingService : ITrainingService  
    {
        private readonly ITrainingRepository _repo;
        public TrainingService(ITrainingRepository repo)
        {
            _repo = repo;
        }
        public Task<List<TrainingStatusDto>> GetStatusList() => _repo.GetStatusList();
        public Task<List<TrainingDurationDto>> GetDurationList() => _repo.GetDurationList();
        public async Task<int> SaveTrainingAsync(TrainingMasterDto training)
        {
            return await _repo.InsertOrUpdateTrainingAsync(training);
        }
        public Task<List<TrainingMasterResponseDto>> GetTrainingAsync() => _repo.GetTrainingAsync();

    }
}
