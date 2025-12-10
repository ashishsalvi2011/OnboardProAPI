using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using OnboardPro.Interfaces.Repositories;
using OnboardPro.Interfaces.Services;
using OnboardPro.Models;
using System.Data;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace OnboardPro.Repositories
{
    public class UserMasterRepository :IUserMasterRepository
    {

        private readonly IConfiguration _configuration;
        public UserMasterRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public async Task<List<RoleDto>> GetActiveRolesAsync()
        {
            using var connection = new SqlConnection(_configuration.GetConnectionString("App1"));
            {
                var role = await connection.QueryAsync<RoleDto>(
                    "sp_GetActiveRoles",
                    commandType: CommandType.StoredProcedure
                );
                return role.ToList();
            }
        }
        public async Task<int> InsertOrUpdateUserAsync(UserDto user)
        {
            using var connection = new SqlConnection(_configuration.GetConnectionString("App1"));
            {
                var parameters = new DynamicParameters();
                parameters.Add("@UserId", user.UserId == 0 ? (int?)null : user.UserId);
                parameters.Add("@PsNumber", user.PsNumber);
                parameters.Add("@Name", user.Name);
                parameters.Add("@ProjectId", user.Project);
                parameters.Add("@MobileNo", user.MobileNo);
                parameters.Add("@EmailId", user.EmailId);
                parameters.Add("@Gender", user.Gender);
                parameters.Add("@DateOfBirth", user.DateOfBirth);
                parameters.Add("@RoleId", user.UserType);
                parameters.Add("@IsActive", user.IsActive);
                parameters.Add("@CreatedBy", user.CreatedBy);
                parameters.Add("@UpdatedBy", user.UpdatedBy);

                var result = await connection.QueryFirstOrDefaultAsync<int>(
                    "sp_InsertOrUpdateUser",
                    parameters,
                    commandType: CommandType.StoredProcedure
                );

                return  result;
            }
        }
        public async Task<List<UserResponseDto>> GetUsersAsync()
        {
            using var connection = new SqlConnection(_configuration.GetConnectionString("App1"));
            {
                var role = await connection.QueryAsync<UserResponseDto>(
                    "sp_GetUsersWithProjectAndRole",
                    commandType: CommandType.StoredProcedure
                );
                return role.ToList();
            }
        }

    }
}
