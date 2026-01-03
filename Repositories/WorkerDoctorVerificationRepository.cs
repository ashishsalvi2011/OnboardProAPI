using Azure.Core;
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
        public async Task<List<WorkerDoctorVerificationDto>> GetWorkersReadyForDoctorVerificationAsync()
        {
            using var connection = new SqlConnection(_configuration.GetConnectionString("App1"));
            {
                var workerReadyForDoctorVerification = await connection.QueryAsync<WorkerDoctorVerificationDto>(
                    "[sp_GetWorkersReadyForDoctorVerification]",
                    commandType: CommandType.StoredProcedure
                );
                return workerReadyForDoctorVerification.ToList();
            }
        }
        public async Task<int> SaveDoctorVerificationAsync(DoctorVerificationRequestDto dto)
        {
            using var connection = new SqlConnection(_configuration.GetConnectionString("App1"));
            {
                var responseTable = CreateResponseDataTable(dto.Questions);

                var parameters = new DynamicParameters();

                parameters.Add("@VerificationID", dto.VerificationID);
                parameters.Add("@WorkerID", dto.WorkerId);
                parameters.Add("@PrescriptionAttached", dto.PrescriptionAttached);

                parameters.Add(
                    "@ResponseList",
                    responseTable.AsTableValuedParameter("dbo.DoctorVerificationResponseType")
                );

                parameters.Add("@UserId", dto.UserId);

                var result =  await connection.ExecuteAsync(
                    "sp_InsertOrUpdateDoctorVerification",
                    parameters,
                    commandType: CommandType.StoredProcedure
                );

                return result;
            }
        }
        private DataTable CreateResponseDataTable(List<DoctorQuestionAnswerDto> responses)
        {
            var table = new DataTable();

            table.Columns.Add("question_id", typeof(int));
            table.Columns.Add("boolean_response", typeof(bool));
            table.Columns.Add("remarks", typeof(string));

            foreach (var r in responses)
            {
                table.Rows.Add(
                    r.QuestionId,
                    r.Answer,
                    r.Remark
                );
            }

            return table;
        }
        public async Task<int> ReturnWorkerDoctorVerification(WorkerDoctorVerificationReturnDto dto)
        {
            using var connection = new SqlConnection(_configuration.GetConnectionString("App1"));
            {
                var parameters = new DynamicParameters();

                parameters.Add("@WorkerID", dto.WorkerId);
                parameters.Add("@ReturnReason", dto.ReturnReason);
                parameters.Add("@UserID", dto.UserId);

                var result = await connection.QueryFirstOrDefaultAsync<int>(
                    "sp_ReturnWorkerDoctorVerification",
                    parameters,
                    commandType: CommandType.StoredProcedure
                );

                return result;
            }
        }
    }
}
