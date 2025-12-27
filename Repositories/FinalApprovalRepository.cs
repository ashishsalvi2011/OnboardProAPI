using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using OnboardPro.Interfaces.Repositories;
using OnboardPro.Models;
using System.Data;

namespace OnboardPro.Repositories
{
    public class FinalApprovalRepository : IFinalApprovalRepository
    {
        private readonly IConfiguration _configuration;
        public FinalApprovalRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public async Task<List<WorkerFinalApprovalDto>> GetFinalApprovalReadyWorkersAsync()
        {
            using var connection = new SqlConnection(_configuration.GetConnectionString("App1"));
            {
                var finalApproval = await connection.QueryAsync<WorkerFinalApprovalDto>(
                    "[sp_GetWorkersReadyForFinalApproval]",
                    commandType: CommandType.StoredProcedure
                );
                return finalApproval.ToList();
            }
        }
        public async Task<int> FinalApproveWorkerAsync(FinalApproveWorkerDto dto)
        {
            using var connection = new SqlConnection(_configuration.GetConnectionString("App1"));
            {
                var parameters = new DynamicParameters();
                parameters.Add("@WorkerID", dto.WorkerID);
                parameters.Add("@IsOnboard", dto.IsOnboard);
                parameters.Add("@HROnboardedBy", dto.HROnboardedBy);
                parameters.Add("@OnboardRemark", dto.OnboardRemark);

                var result = await connection.QueryFirstOrDefaultAsync<int>(
                    "[sp_FinalApproveWorkerOnboard]",
                    parameters,
                    commandType: CommandType.StoredProcedure
                );

                return result;
            }
        }
    }
}
