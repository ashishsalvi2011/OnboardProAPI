using OnboardPro.Models;

namespace OnboardPro.Interfaces.Repositories
{
    public interface ITrainingRepository
    {
        Task<List<TrainingStatusDto>> GetStatusList();
        Task<List<TrainingDurationDto>> GetDurationList();
        Task<int> InsertOrUpdateTrainingAsync(TrainingMasterDto training);
        Task<List<TrainingMasterResponseDto>> GetTrainingAsync();
    }
}
