using Dapper;
using Microsoft.Data.SqlClient;
using OnboardPro.Interfaces.Repositories;
using OnboardPro.Models;
using System.Data;

namespace OnboardPro.Repositories
{
    public class WorkerDoctorVerificationRepository : IWorkerDoctorVerificationRepository
    {
        private readonly IConfiguration _configuration;
        public WorkerDoctorVerificationRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public async Task<List<QuestionDto>> GetAllQuestions()
        {
            using var connection = new SqlConnection(_configuration.GetConnectionString("App1"));
            {
                var questions = await connection.QueryAsync<QuestionDto>(
                    "[sp_GetDoctorAllQuestions]",
                    commandType: CommandType.StoredProcedure
                );
                return questions.ToList();
            }
        }
        public async Task<List<WorkerMedicalVerificationDto>> GetWorkersReadyForMedicalVerificationAsync()
        {
            using var connection = new SqlConnection(_configuration.GetConnectionString("App1"));
            {
                var workerSkills = await connection.QueryAsync<WorkerMedicalVerificationDto>(
                    "[sp_GetWorkersReadyForMedicalVerification]",
                    commandType: CommandType.StoredProcedure
                );
                return workerSkills.ToList();
            }
        }
        public async Task<int> SaveMedicalVerificationAsync(WorkerMedicalVerificationRequestDto dto)
        {
            using var connection = new SqlConnection(_configuration.GetConnectionString("App1"));
            {
                var parameters = new DynamicParameters();
                    parameters.Add("@VerificationID", dto.VerificationID);
                    parameters.Add("@WorkerID", dto.WorkerID);
                    parameters.Add("@HealthCheckDate", dto.HealthCheckupDate);

                    parameters.Add("@Pulse", dto.Pulse);
                    parameters.Add("@SPO2", dto.SPO2);
                    parameters.Add("@RespiratoryRate", dto.Rr);
                    parameters.Add("@SkinTemperatureDegC", dto.SkinTemp);

                    parameters.Add("@BP_Systolic", dto.BpSystolic);
                    parameters.Add("@BP_Diastolic", dto.Diastolic);

                    parameters.Add("@Sugar", dto.Sugar);
                    parameters.Add("@WeightKg", dto.Weight);
                    parameters.Add("@HeightCm", dto.Height);
                    parameters.Add("@BMI", dto.BMI);

                    parameters.Add("@BloodGroup", dto.BloodGroup);

                    parameters.Add("@IsActive", dto.IsVerify);
                    parameters.Add("@UserID", dto.CreatedBy);


                var result = await connection.QueryFirstOrDefaultAsync<int>(
                    "[sp_InsertOrUpdateWorkerMedicalVerification]",
                    parameters,
                    commandType: CommandType.StoredProcedure
                );

                return result;
            }
        }
    }
}
