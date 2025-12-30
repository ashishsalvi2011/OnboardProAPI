using Dapper;
using Microsoft.Data.SqlClient;
using OnboardPro.Interfaces.Repositories;
using OnboardPro.Models;
using System.Data;

namespace OnboardPro.Repositories
{
    public class WorkerPFRepository : IWorkerPFRepository
    {
        private readonly IConfiguration _configuration;
        public WorkerPFRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public async Task<List<WorkerPFDto>> GetWorkersDeatilsForPFAsync()
        {
            using var connection = new SqlConnection(_configuration.GetConnectionString("App1"));
            {
                var workerPFDetails = await connection.QueryAsync<WorkerPFDto>(
                    "[sp_GetWorkerDetailsForPF]",
                    commandType: CommandType.StoredProcedure
                );
                return workerPFDetails.ToList();
            }
        }
        public async Task<int> SavePFAsync(WorkerPfEsiUpsertDto dto)
        {
            using var connection = new SqlConnection(_configuration.GetConnectionString("App1"));
            {
                var parameters = new DynamicParameters();
                parameters.Add("@WorkerID", dto.WorkerID);
                parameters.Add("@UAN", dto.UAN);
                parameters.Add("@UniversalAccountName", dto.UniversalAccountName);
                parameters.Add("@PFNumber", dto.PFNumber);
                parameters.Add("@ESINumber", dto.ESINumber);
                parameters.Add("@IsActive", dto.IsActive);
                parameters.Add("@UserId", dto.UserId);

                return await connection.ExecuteAsync(
                    "sp_UpsertWorkerPFESIDetails",
                    parameters,
                    commandType: CommandType.StoredProcedure
                );
            }
        }
    }
}
