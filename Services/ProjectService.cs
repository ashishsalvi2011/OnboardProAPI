using OnboardPro.Interfaces.Repositories;
using OnboardPro.Interfaces.Services;
using OnboardPro.Models;

namespace OnboardPro.Services
{
    public class ProjectService : IProjectService
    {
        private readonly IProjectRepository _projectRepository;

        public ProjectService(IProjectRepository projectRepository)
        {
            _projectRepository = projectRepository;
        }

        public async Task<int> InsertOrUpdateProjectAsync(ProjectDto model)
        {
            // You can add validations, business logic here
            if (string.IsNullOrWhiteSpace(model.ProjectName))
                throw new Exception("Project Name is required.");

            if (string.IsNullOrWhiteSpace(model.ProjectCode))
                throw new Exception("Project Code is required.");

            return await _projectRepository.InsertOrUpdateProjectAsync(model);
        }

        public Task<List<ProjectListDto>> GetProjectsAsync()
        {
            return _projectRepository.GetProjectsAsync();
        }
    }
}
