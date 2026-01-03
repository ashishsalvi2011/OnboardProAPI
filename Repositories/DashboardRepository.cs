using Dapper;
using Microsoft.Data.SqlClient;
using OnboardPro.Interfaces.Repositories;
using OnboardPro.Models;
using System.Data;
using System.Reflection;

namespace OnboardPro.Repositories
{
    public class DashboardRepository : IDashboardRepository
    {
        private readonly IConfiguration _configuration;
        public DashboardRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public async Task<List<DashboardStatDto>> GeDashboardStatsDatails()
        {
            using var connection = new SqlConnection(_configuration.GetConnectionString("App1"));

            var dashboardStat = await connection.QueryAsync<DashboardStatDto>(
                "sp_GetEmployeeDashboardStats",
                commandType: CommandType.StoredProcedure
            );

            return dashboardStat.ToList();
        }
    }
}
