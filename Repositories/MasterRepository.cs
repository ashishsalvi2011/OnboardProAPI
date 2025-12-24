using Dapper;
using Microsoft.Data.SqlClient;
using OnboardPro.Interfaces.Repositories;
using OnboardPro.Models;
using System.Data;
using System.Reflection;

namespace OnboardPro.Repositories
{
    public class MasterRepository: IMasterRepository
    {
        private readonly IConfiguration _configuration;
        public MasterRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public async Task<List<MasterDto>> GetMasterDataAsync(string? masterType = null)
        {
            using var connection = new SqlConnection(_configuration.GetConnectionString("App1"));

            var parameters = new DynamicParameters();
            parameters.Add("@MasterType", masterType, DbType.String);

            var master = await connection.QueryAsync<MasterDto>(
                "usp_GetMasterData",
                parameters,
                commandType: CommandType.StoredProcedure
            );

            return master.ToList();
        }
    }
}
