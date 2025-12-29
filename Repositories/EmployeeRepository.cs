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


    }
}
