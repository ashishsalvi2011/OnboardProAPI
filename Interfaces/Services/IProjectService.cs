using OnboardPro.Models;

namespace OnboardPro.Interfaces.Services
{
    public interface IProjectService
    {
        Task<int> InsertOrUpdateProjectAsync(ProjectDto model);
        Task<List<ProjectListDto>> GetProjectsAsync();
    }
}
