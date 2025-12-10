using OnboardPro.Models;

namespace OnboardPro.Interfaces.Repositories
{
    public interface IProjectRepository
    {
        Task<int> InsertOrUpdateProjectAsync(ProjectDto model);
        Task<List<ProjectListDto>> GetProjectsAsync();
    }
}
