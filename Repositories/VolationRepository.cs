using Dapper;
using Microsoft.Data.SqlClient;
using OnboardPro.Interfaces.Repositories;
using OnboardPro.Models;
using System.Data;
using System.Reflection;

namespace OnboardPro.Repositories
{
    public class ViolationRepository: IViolationRepository
    {
        private readonly IConfiguration _configuration;
        public ViolationRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public async Task<List<ViolationLevelDto>> GetViolationLevelDataAsync()
        {
            using var connection = new SqlConnection(_configuration.GetConnectionString("App1"));

            var viloationLevel = await connection.QueryAsync<ViolationLevelDto>(
                "sp_GetMasterViolationLevels",
                commandType: CommandType.StoredProcedure
            );

            return viloationLevel.ToList();
        }
        public async Task<int> SaveViolationAsync(WorkerViolationUpsertDto dto)
        {
            using var connection = new SqlConnection(_configuration.GetConnectionString("App1"));
            {
                var parameters = new DynamicParameters();
                parameters.Add("@WorkerID", dto.WorkerID);
                parameters.Add("@ViolationID", dto.ViolationID);
                parameters.Add("@ViolationLevelID", dto.ViolationLevelID);
                parameters.Add("@ViolationReason", dto.ViolationReason);
                parameters.Add("@IsActive", dto.IsActive);
                parameters.Add("@UserID", dto.UserID);

                var result = await connection.ExecuteAsync(
                    "sp_InsertOrUpdateWorkerViolation",
                    parameters,
                    commandType: CommandType.StoredProcedure
                );

                return result;
            }
        }
        public async Task<List<WorkerViolationReasonDto>> GetViolationReasonListAsync(int? workerId)
        {
            using var connection = new SqlConnection(_configuration.GetConnectionString("App1"));

            var parameters = new DynamicParameters();
            parameters.Add("@WorkerID", workerId);

            var violationReasonList = await connection.QueryAsync<WorkerViolationReasonDto>(
                "sp_GetWorkerViolationReasonList",
                parameters,
                commandType: CommandType.StoredProcedure
            );

            return violationReasonList.ToList();
        }

    }
}
