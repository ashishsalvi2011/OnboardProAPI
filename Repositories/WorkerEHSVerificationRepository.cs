using Dapper;
using Microsoft.Data.SqlClient;
using OnboardPro.Interfaces.Repositories;
using OnboardPro.Models;
using System.Data;

namespace OnboardPro.Repositories
{
    public class WorkerEHSVerificationRepository : IWorkerEHSVerificationRepository
    {
        private readonly IConfiguration _configuration;
        public WorkerEHSVerificationRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public async Task<List<EHSVerificationPendingDto>> GetWorkersReadyForEHSVerificationAsync()
        {
            using var connection = new SqlConnection(_configuration.GetConnectionString("App1"));
            {
                var workerSkills = await connection.QueryAsync<EHSVerificationPendingDto>(
                    "[sp_GetWorkersReadyForEHSVerificaton]",
                    commandType: CommandType.StoredProcedure
                );
                return workerSkills.ToList();
            }
        }
        public async Task<int> SaveEHSVerificationAsync(EHSVerificationSaveDto dto)
        {
            using var connection = new SqlConnection(_configuration.GetConnectionString("App1"));
            {
                var parameters = new DynamicParameters();

                parameters.Add("@EHSVerificationID", dto.EHSVerificationID);
                parameters.Add("@WorkerID", dto.WorkerID);
                parameters.Add("@VendorID", dto.VendorID);

                parameters.Add("@EHSInCharge", dto.EhsInchargeId);
                parameters.Add("@HeightTest", dto.HeightTest);

                parameters.Add("@MedicalVerificationDoneBy", dto.MedicalVerifiedById    );
                parameters.Add("@DoctorVerificationDoneBy", dto.DoctorVerificationDoneBy);
                parameters.Add("@WorkForceCreatedBy", dto.WorkforceCreatedById);
                parameters.Add("@SkillVerificationDoneBy", dto.SkillVerifiedById);

                parameters.Add("@SafetyInductionConductedOn", dto.SafetyInductionDate);
                parameters.Add("@Remark", dto.Remarks);

                parameters.Add("@IsActive", dto.IsActive);
                parameters.Add("@UserID", dto.UserID);



                var result = await connection.QueryFirstOrDefaultAsync<int>(
                    "[sp_InsertOrUpdateEHSVerification]",
                    parameters,
                    commandType: CommandType.StoredProcedure
                );

                return result;
            }
        }
        public async Task<int> ReturnWorkerEHSVerification(WorkerEHSVerificationReturnDto dto)
        {
            using var connection = new SqlConnection(_configuration.GetConnectionString("App1"));
            {
                var parameters = new DynamicParameters();

                parameters.Add("@WorkerID", dto.WorkerId);
                parameters.Add("@ReturnReason", dto.ReturnReason);
                parameters.Add("@UserID", dto.UserId);

                var result = await connection.QueryFirstOrDefaultAsync<int>(
                    "sp_ReturnWorkerEHSVerification",
                    parameters,
                    commandType: CommandType.StoredProcedure
                );

                return result;
            }
        }
    }
}
