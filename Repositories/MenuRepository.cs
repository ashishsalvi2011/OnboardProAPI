using Dapper;
using Microsoft.Data.SqlClient;
using OnboardPro.Interfaces.Repositories;
using OnboardPro.Models;
using System.Data;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace OnboardPro.Repositories
{
    public class MenuRepository : IMenuRepository
    {
        private readonly IConfiguration _configuration;

        public MenuRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<IEnumerable<MenuDto>> GetMenusByRoleAsync(int roleId)
        {
            using var connection = new SqlConnection(_configuration.GetConnectionString("App1"));
            var parameters = new DynamicParameters();
            parameters.Add("@RoleId", roleId, DbType.Int32);

            var menus = await connection.QueryAsync<MenuDto>(
                "[dbo].[sp_GetMenusByRole]",
                parameters,
                commandType: CommandType.StoredProcedure
            );

            return menus;
        }
    }
}
