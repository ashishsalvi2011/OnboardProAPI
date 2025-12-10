using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using OnboardPro.Interfaces.Repositories;
using OnboardPro.Models;
using System.Data;

namespace OnboardPro.Repositories
{
    public class SkillMasterRepository : ISkillMasterRepository
    {
        private readonly IConfiguration _configuration;

        public SkillMasterRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<SkillMasterResponse> GetSkillMasterDataAsync()
        {
            using var connection = new SqlConnection(_configuration.GetConnectionString("App1"));
            {
                using (var multi = await connection.QueryMultipleAsync(
                    "sp_GetAllSkillMasterData",
                    commandType: CommandType.StoredProcedure))
                {
                    var groups = await multi.ReadAsync<SkillGroupDto>();
                    var subGroups = await multi.ReadAsync<SkillSubGroupDto>();
                    var categories = await multi.ReadAsync<SkillCategoryDto>();

                    return new SkillMasterResponse
                    {
                        SkillGroups = groups,
                        SkillSubGroups = subGroups,
                        SkillCategories = categories
                    };
                }
            }
        }

        public async Task<int> InsertOrUpdateSkillAsync(SkillDto skill)
        {
            using var connection = new SqlConnection(_configuration.GetConnectionString("App1"));
            {
                var parameters = new DynamicParameters();
                parameters.Add("@SkillId", skill.SkillId);
                parameters.Add("@SkillName", skill.SkillName);
                parameters.Add("@Description", skill.Description);
                parameters.Add("@SkillGroupId", skill.SkillGroupId);
                parameters.Add("@SkillSubGroupId", skill.SkillSubGroupId);
                parameters.Add("@SkillCategoryId", skill.SkillCategoryId);
                parameters.Add("@IsActive", skill.IsActive);
                parameters.Add("@CreatedBy", skill.CreatedBy);
                parameters.Add("@UpdatedBy", skill.UpdatedBy);

                var result = await connection.QueryFirstOrDefaultAsync<int>(
                    "sp_InsertOrUpdateSkillMaster",
                    parameters,
                    commandType: CommandType.StoredProcedure
                );

                return result;
            }
        }

        public async Task<List<SkillResponseDto>> GetAllSkillsAsync()
        {
            using var connection = new SqlConnection(_configuration.GetConnectionString("App1"));
            {
                var skills = await connection.QueryAsync<SkillResponseDto>(
                    "sp_GetSkillsMaster",
                    commandType: CommandType.StoredProcedure
                );
                return skills.ToList();
            }
        }
    }
}
