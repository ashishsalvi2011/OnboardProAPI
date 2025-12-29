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
        public async Task<List<DraftWorkerDto>> GetDraftWorkersAsync()
        {
            using var connection = new SqlConnection(_configuration.GetConnectionString("App1"));
            {
                var vendors = await connection.QueryAsync<DraftWorkerDto>(
                    "sp_GetDraftWorkers",
                    commandType: CommandType.StoredProcedure
                );
                return vendors.ToList();
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
        public async Task<List<OnBoardWorkerDto>> GetOnBoardWorkersAsync()
        {
            using var connection = new SqlConnection(_configuration.GetConnectionString("App1"));
            {
                var onBoardWorkers = await connection.QueryAsync<OnBoardWorkerDto>(
                    "[sp_GetOnBoardWorkers]",
                    commandType: CommandType.StoredProcedure
                );
                return onBoardWorkers.ToList();
            }
        }

    }
}
