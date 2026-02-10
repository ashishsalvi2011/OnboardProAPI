using Azure.Core;
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using OnboardPro.Interfaces.Repositories;
using OnboardPro.Models;
using System.Data;

namespace OnboardPro.Repositories
{
    public class EmployeeRepository: IEmployeeRepository
    {
        private readonly IConfiguration _configuration;
        public EmployeeRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public async Task<List<DraftWorkerDto>> GetDraftWorkersAsync(int userId)
        {
            using var connection = new SqlConnection(_configuration.GetConnectionString("App1"));
            {
                var parameters = new DynamicParameters();
                parameters.Add("@userId", userId);

                var vendors = await connection.QueryAsync<DraftWorkerDto>(
                    "sp_GetDraftWorkers", parameters,
                    commandType: CommandType.StoredProcedure
                );
                return vendors.ToList();
            }
        }
        public async Task<List<OnBoardWorkerDto>> GetWorkersForExit(int userId)
        {
            using var connection = new SqlConnection(_configuration.GetConnectionString("App1"));
            {
                var parameters = new DynamicParameters();
                parameters.Add("@userId", userId);

                var onBoardWorkers = await connection.QueryAsync<OnBoardWorkerDto>(
                    "[sp_GetWorkersForExit]", parameters,
                    commandType: CommandType.StoredProcedure
                );
                return onBoardWorkers.ToList();
            }
        }
        public async Task<int> ExitWorkerAsync(ExitWorkerDto dto)
        {
            using var connection = new SqlConnection(_configuration.GetConnectionString("App1"));
            {
                var parameters = new DynamicParameters();
                parameters.Add("@WorkerId", dto.WorkerId);
                parameters.Add("@ExitDate", dto.ExitDate);
                parameters.Add("@ExitReason", dto.ExitReason);
                parameters.Add("@ExitType", dto.ExitType);
                parameters.Add("@CreatedBy", dto.CreatedBy);

                var result = await connection.QueryFirstOrDefaultAsync<int>(
                    "[sp_ExitWorker]",
                    parameters,
                    commandType: CommandType.StoredProcedure
                );

                return result;
            }
        }
        public async Task<List<OnBoardWorkerDto>> GetOnBoardWorkersAsync(int userId)
        {
            using var connection = new SqlConnection(_configuration.GetConnectionString("App1"));
            {
                var parameters = new DynamicParameters();
                parameters.Add("@userId", userId);

                var onBoardWorkers = await connection.QueryAsync<OnBoardWorkerDto>(
                    "[sp_GetOnBoardWorkers]", parameters,
                    commandType: CommandType.StoredProcedure
                );
                return onBoardWorkers.ToList();
            }
        }
        public async Task<List<WorkerIdCardDto>> GetWorkerIdCardAsync(int userId)
        {

            using var connection = new SqlConnection(_configuration.GetConnectionString("App1"));
            {
                var parameters = new DynamicParameters();
                parameters.Add("@userId", userId);

                var idCardDetails = await connection.QueryAsync<WorkerIdCardDto>(
                    "sp_GetIDCardDetails", parameters,
                    commandType: CommandType.StoredProcedure
                );
                return idCardDetails.ToList();
            }
        }
        public async Task<int> InsertOrUpdateWorkerRewardAsync(WorkerRewardUpsertDto dto)
        {
            using var connection = new SqlConnection(_configuration.GetConnectionString("App1"));
            {
                var parameters = new DynamicParameters();

                parameters.Add("@RewardID", dto.RewardID);
                parameters.Add("@WorkerID", dto.WorkerID);
                parameters.Add("@RewardReason", dto.RewardReason);
                parameters.Add("@IsActive", dto.IsActive);
                parameters.Add("@UserID", dto.UserID);

                var result = await connection.QueryFirstOrDefaultAsync<int>(
                    "[sp_InsertOrUpdateWorkerReward]",
                    parameters,
                    commandType: CommandType.StoredProcedure
                );

                return result;
            }
        }
        public async Task<int> BlockOrUnblockWorkerAsync(WorkerBlockRequestDto dto)
        {
            using var connection = new SqlConnection(_configuration.GetConnectionString("App1"));
            {
                var parameters = new DynamicParameters();
                parameters.Add("@WorkerID", dto.WorkerId);
                parameters.Add("@Action", dto.Action);
                parameters.Add("@Reason", dto.Reason);
                parameters.Add("@UserID", dto.UserId);

                var result = await connection.QueryFirstOrDefaultAsync<int>(
                    "[sp_BlockOrUnblockWorker]",
                    parameters,
                    commandType: CommandType.StoredProcedure
                );

                return result;
            }
        }
        public async Task<List<ReturnedWorkerDto>> GetReturnedWorkersAsync(int userId)
        {
            using var connection = new SqlConnection(_configuration.GetConnectionString("App1"));
            {
                var parameters = new DynamicParameters();
                parameters.Add("@userId", userId);

                var returnWorkers = await connection.QueryAsync<ReturnedWorkerDto>(
                    "[sp_GetReturnedWorkerList]", parameters,
                    commandType: CommandType.StoredProcedure
                );
                return returnWorkers.ToList();
            }
        }
        public async Task<int> UpdateWokerGatePassDetails(WorkerWageDto dto)
        {
            using var connection = new SqlConnection(_configuration.GetConnectionString("App1"));
            {
                var parameters = new DynamicParameters();
                parameters.Add("@WorkerId", dto.WorkerId);
                parameters.Add("@FromDate", dto.FromDate);
                parameters.Add("@ToDate", dto.ToDate);
                parameters.Add("@DailyWage", dto.DailyWage);
                parameters.Add("@EmergencyContact", dto.EmergencyContact);
                parameters.Add("@UserId", dto.UserId);

                var result = await connection.QueryFirstOrDefaultAsync<int>(
                    "[sp_UpdateWokerGatePassDetails]",
                    parameters,
                    commandType: CommandType.StoredProcedure
                );

                return result;
            }
        }

    }
}
