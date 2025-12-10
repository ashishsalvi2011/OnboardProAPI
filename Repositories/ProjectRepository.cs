using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using OnboardPro.Interfaces.Repositories;
using OnboardPro.Models;
using System.Data;

namespace OnboardPro.Repositories
{
    public class ProjectRepository : IProjectRepository
    {

        private readonly IConfiguration _configuration;

        public ProjectRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<int> InsertOrUpdateProjectAsync(ProjectDto model)
        {
            using var connection = new SqlConnection(_configuration.GetConnectionString("App1"));

            var parameters = new DynamicParameters();
            parameters.Add("@ProjectId", model.ProjectId, DbType.Int32);
            parameters.Add("@ProjectName", model.ProjectName);
            parameters.Add("@ProjectCode", model.ProjectCode);
            parameters.Add("@CompanyId", model.CompanyId);
            parameters.Add("@Location", model.Location);
            parameters.Add("@CustomerName", model.CustomerName);
            parameters.Add("@HelplineNumber", model.HelplineNumber);
            parameters.Add("@IsActive", model.IsActive);
            parameters.Add("@UserId", model.UserId);

            var result = await connection.ExecuteScalarAsync<int>(
                "sp_InsertOrUpdateProject",
                parameters,
                commandType: CommandType.StoredProcedure
            );

            return result;
        }

        public async Task<List<ProjectListDto>> GetProjectsAsync()
        {
            using var connection = new SqlConnection(_configuration.GetConnectionString("App1"));

            var result = await connection.QueryAsync<ProjectListDto>(
                "sp_GetProjects",
                commandType: CommandType.StoredProcedure
            );

            return result.ToList();
        }
    }
}
