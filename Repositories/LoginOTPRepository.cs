using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using OnboardPro.Interfaces.Repositories;
using OnboardPro.Models;
using System.Data;
using System.Diagnostics;
using System.Threading.Tasks;

namespace OnboardPro.Repository
{
    public class LoginOTPRepository : ILoginOTPRepository
    {
        private readonly IConfiguration _config;

        public LoginOTPRepository(IConfiguration config)
        {
            _config = config;
        }

        private IDbConnection Connection => new SqlConnection(_config.GetConnectionString("App1"));

        public async Task<OTPResponse> SendOTPAsync(LoginOTPRequest request)
        {
            using (var conn = Connection)
            {
                var result = await conn.QueryFirstOrDefaultAsync<OTPResponse>(
                    "sp_SendLoginOTP",
                    new
                    {
                        request.MobileNo,
                        request.UserId,
                        request.IPAddress,
                        request.DeviceInfo,
                        request.CreatedBy
                    },
                    commandType: CommandType.StoredProcedure
                );
                return result ?? new OTPResponse { Status = false, Message = "Failed to send OTP." };
            }
        }

        public async Task<VerifyOTPResponse> VerifyOTPAsync(VerifyOTPRequest request)
        {
            using (var conn = Connection)
            {
                var result = await conn.QueryFirstOrDefaultAsync<VerifyOTPResponse>(
                    "sp_VerifyLoginOTP",
                    new { request.MobileNo, request.OTPCode },
                    commandType: CommandType.StoredProcedure
                );


                return new VerifyOTPResponse
                {
                    UserId = result?.UserId ?? request.UserId,
                    RoleId = result?.RoleId ?? request.RoleId,
                    Username = result?.Username ?? request.Username,
                    Status = result?.Status ?? false,
                    Message = result?.Message ?? "Verification failed."
                };
            }
        }

        public async Task<UserResponse> GetUserByMobileAsync(string mobileNo)
        {
            using (var connection = Connection)
            {
                var result = await connection.QueryAsync<UserResponse>(
                    "sp_GetUserByMobile",
                    new { MobileNo = mobileNo },
                    commandType: CommandType.StoredProcedure
                );

                return result.FirstOrDefault() ?? new UserResponse
                {
                    Success = 0,
                    Message = "User not found."
                };
            }
        }
    }
}
