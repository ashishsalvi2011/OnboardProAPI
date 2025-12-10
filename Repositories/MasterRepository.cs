using Dapper;
using Microsoft.Data.SqlClient;
using OnboardPro.Interfaces.Repositories;
using OnboardPro.Models;
using System.Data;

namespace OnboardPro.Repositories
{
    public class MasterRepository: IMasterRepository
    {
        private readonly IConfiguration _configuration;

        public MasterRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<List<GenderDto>> GetGenders()
        {
            using var connection = new SqlConnection(_configuration.GetConnectionString("App1"));
            {
                var gender = await connection.QueryAsync<GenderDto>(
                    "sp_GetGenders",
                    commandType: CommandType.StoredProcedure
                );
                return gender.ToList();
            }
        }

 
    }
}
