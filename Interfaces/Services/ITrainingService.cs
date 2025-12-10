using OnboardPro.Models;

namespace OnboardPro.Interfaces.Services
{
    public interface ITrainingService
    {
        Task<List<TrainingStatusDto>> GetStatusList();
        Task<List<TrainingDurationDto>> GetDurationList();
        Task<int> SaveTrainingAsync(TrainingMasterDto user);
        Task<List<TrainingMasterResponseDto>> GetTrainingAsync();
    }
}
