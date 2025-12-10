using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using OnboardPro.Interfaces.Repositories;
using OnboardPro.Models;
using System.Data;

namespace OnboardPro.Repositories
{
    public class VendorMasterRepository:IVendorMasterRepository
    {
        private readonly IConfiguration _configuration;

        public VendorMasterRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public async Task<int> InsertOrUpdateVendorAsync(VendorMasterDto vendor)
        {
            using var connection = new SqlConnection(_configuration.GetConnectionString("App1"));
            {
                var parameters = new DynamicParameters();

                parameters.Add("@VendorId", vendor.VendorId == 0 ? 0 : vendor.VendorId);

                parameters.Add("@VendorCode", vendor.VendorCode);
                parameters.Add("@VendorName", vendor.VendorName);

                parameters.Add("@ProjectId", vendor.Project);
                parameters.Add("@IsActive", vendor.IsActive);

                parameters.Add("@ContactNumber", vendor.ContactNumber);
                parameters.Add("@ContactPerson", vendor.ContactPerson);

                parameters.Add("@Email", vendor.Email);

                parameters.Add("@GSTNo", vendor.GSTNo);
                parameters.Add("@PANNo", vendor.PANNo);
                parameters.Add("@TANNo", vendor.TANNo);
                parameters.Add("@PFCode", vendor.PFCode);
                parameters.Add("@BOCWCode", vendor.BOCWCode);
                parameters.Add("@ISMWCode", vendor.ISMWCode);

                parameters.Add("@UserId", vendor.UpdatedBy > 0 ? vendor.UpdatedBy : vendor.CreatedBy);

                var result = await connection.QueryFirstOrDefaultAsync<int>(
                    "sp_InsertOrUpdateVendor",
                    parameters,
                    commandType: CommandType.StoredProcedure
                );
                return result;
            }
        }

        public async Task<List<VendorResponseDto>> GetVendorAsync()
        {
            using var connection = new SqlConnection(_configuration.GetConnectionString("App1"));
            {
                var vendors = await connection.QueryAsync<VendorResponseDto>(
                    "sp_GetVendors",
                    commandType: CommandType.StoredProcedure
                );
                return vendors.ToList();
            }
        }
    }
}
