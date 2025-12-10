using Dapper;
using Microsoft.Data.SqlClient;
using OnboardPro.Interfaces.Repositories;
using OnboardPro.Models;
using System.Data;
using System.Numerics;

namespace OnboardPro.Repositories
{
    public class TrainingRepository : ITrainingRepository
    {
        private readonly IConfiguration _configuration;

        public TrainingRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public async Task<List<TrainingStatusDto>> GetStatusList()
        {
            using var connection = new SqlConnection(_configuration.GetConnectionString("App1"));
            {
                var status = await connection.QueryAsync<TrainingStatusDto>(
                    "sp_GetTrainingStatusList",
                    commandType: CommandType.StoredProcedure
                );
                return status.ToList();
            }
        }
        public async Task<List<TrainingDurationDto>> GetDurationList()
        {
            using var connection = new SqlConnection(_configuration.GetConnectionString("App1"));
            {
                var duration = await connection.QueryAsync<TrainingDurationDto>(
                    "sp_GetTrainingDurationList",
                    commandType: CommandType.StoredProcedure
                );
                return duration.ToList();
            }
        }
        public async Task<int> InsertOrUpdateTrainingAsync(TrainingMasterDto training)
        {
            using var connection = new SqlConnection(_configuration.GetConnectionString("App1"));
            {
                var parameters = new DynamicParameters();

                parameters.Add("@TrainingId", training.TrainingId == 0 ? (int?)null : training.TrainingId);
                parameters.Add("@TopicName", training.TopicName);
                parameters.Add("@TrainingDate", training.TrainingDate);
                parameters.Add("@ImpartedBy", training.ImpartedBy);
                parameters.Add("@Duration", training.Duration);
                parameters.Add("@Status", training.Status);
                parameters.Add("@Description", training.Description);
                parameters.Add("@UserId", training.UpdatedBy != "" ? training.UpdatedBy : training.CreatedBy);

                var result = await connection.QueryFirstOrDefaultAsync<int>(
                    "sp_InsertOrUpdateTraining",
                    parameters,
                    commandType: CommandType.StoredProcedure
                );

                return result;
            }
        }
        public async Task<List<TrainingMasterResponseDto>> GetTrainingAsync()
        {
            using var connection = new SqlConnection(_configuration.GetConnectionString("App1"));
            {
                var duration = await connection.QueryAsync<TrainingMasterResponseDto>(
                    "sp_GetTrainingList",
                    commandType: CommandType.StoredProcedure
                );
                return duration.ToList();
            }
        }
    }
}
