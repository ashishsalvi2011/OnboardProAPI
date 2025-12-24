using Dapper;
using Microsoft.Data.SqlClient;
using OnboardPro.Interfaces.Repositories;
using OnboardPro.Models;
using System.Data;

namespace OnboardPro.Repositories
{
    public class WorkerSkillVerificationRepository : IWorkerSkillVerificationRepository
    {
        private readonly IConfiguration _configuration;
        public WorkerSkillVerificationRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public async Task<List<WorkerSkillVerificationDto>> GetWorkersReadyForSkillVerificationAsync()
        {
            using var connection = new SqlConnection(_configuration.GetConnectionString("App1"));
            {
                var workerSkills = await connection.QueryAsync<WorkerSkillVerificationDto>(
                    "sp_GetWorkersReadyForSkillVerification",
                    commandType: CommandType.StoredProcedure
                );
                return workerSkills.ToList();
            }
        }
        public async Task<SkillAndProficiencyResponseDto> GetSkillAndProficiencyAsync()
        {
            using var connection = new SqlConnection(_configuration.GetConnectionString("App1"));
            {
                var multi = await connection.QueryMultipleAsync(
                    "sp_GetSkillAndProficiencyMaster",
                    commandType: CommandType.StoredProcedure
                );

                var skills = (await multi.ReadAsync<SkillDto>()).ToList();
                var proficiencies = (await multi.ReadAsync<SkillProficiencyDto>()).ToList();

                return new SkillAndProficiencyResponseDto
                {
                    Skills = skills,
                    Proficiencies = proficiencies
                };
            }
        }
        public async Task<int> SaveSkillVerificationAsync(WorkerSkillVerificationSubmitDto dto)
        {
            using var connection = new SqlConnection(_configuration.GetConnectionString("App1"));
            {
                var parameters = new DynamicParameters();
                parameters.Add("@VerificationID", dto.VerificationId);
                parameters.Add("@WorkerID", dto.WorkerId);
                parameters.Add("@SkillId", dto.SkillId);
                parameters.Add("@SkillPerformance", dto.ProficiencyId);
                parameters.Add("@IsActive", dto.IsVerify);
                parameters.Add("@UserID", dto.CreatedBy);

                var result = await connection.QueryFirstOrDefaultAsync<int>(
                    "sp_InsertOrUpdateWorkerSkillVerification",
                    parameters,
                    commandType: CommandType.StoredProcedure
                );

                return result;
            }
        }

    }
}
