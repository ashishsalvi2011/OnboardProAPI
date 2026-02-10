using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using OnboardPro.Interfaces.Repositories;
using OnboardPro.Models;
using System.Data;
using System.Reflection;
using System.Text.Json;

namespace OnboardPro.Repositories
{
    public class ComplianceRepository:IComplianceRepository
    {

        private readonly IConfiguration _configuration;
        public ComplianceRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public async Task<int> SaveLicenseWithFilesAsync(ContractLabourLicenseDto dto)
        {
            using var connection = new SqlConnection(_configuration.GetConnectionString("App1"));
            {
                var parameters = new DynamicParameters();

                parameters.Add("@LicenseNumber", dto.LicenseNumber);
                parameters.Add("@IssuedByOffice", dto.IssuedByOfficeAddress);
                parameters.Add("@NumberOfWorkmen", dto.NumberOfWorkmen);
                parameters.Add("@SecurityDepositPerWorker", dto.SecurityDepositPerWorkmen);
                parameters.Add("@LicenseFromDate", dto.ValidityFrom);
                parameters.Add("@LicenseToDate", dto.ValidityTo);
                parameters.Add("@CreatedBy", dto.UserId);

                string? filesJson = dto.Files != null && dto.Files.Any()
                    ? JsonSerializer.Serialize(dto.Files)
                    : null;

                parameters.Add("@FilesJson", filesJson);

                var licenseId = await connection.ExecuteScalarAsync<int>(
                    "sp_SaveContractLabourLicense_WithFiles",
                    parameters,
                    commandType: CommandType.StoredProcedure
                );

                return licenseId;
            }
        }
        public async Task<int> SaveBOCWAsync(BOCWLicenseDto dto)
        {
            using var connection = new SqlConnection(_configuration.GetConnectionString("App1"));
            {
                var parameters = new DynamicParameters();

                parameters.Add("@LicenseNumber", dto.LicenseNumber);
                parameters.Add("@IssuedByOffice", dto.IssuedByOfficeAddress);
                parameters.Add("@NumberOfWorkmen", dto.NumberOfWorkmen);
                parameters.Add("@DepositAmount", dto.DepositAmount);
                parameters.Add("@SecurityDepositPerWorker", dto.SecurityDepositPerWorkmen);
                parameters.Add("@Remark", dto.Remark);

                parameters.Add("@LicenseFromDate", dto.ValidityFrom);
                parameters.Add("@LicenseToDate", dto.ValidityTo);

                parameters.Add("@LicenseToDate", dto.ValidityTo);
                parameters.Add("@IssuedDate", dto.IssuedDate);

                parameters.Add("@CreatedBy", dto.UserId);

                string? filesJson = dto.Files != null && dto.Files.Any()
                    ? JsonSerializer.Serialize(dto.Files)
                    : null;

                parameters.Add("@FilesJson", filesJson);

                var licenseId = await connection.ExecuteScalarAsync<int>(
                    "sp_SaveBOCWLicense_WithFiles",
                    parameters,
                    commandType: CommandType.StoredProcedure
                );

                return licenseId;
            }
        }
        public async Task<int> SaveInterstateMigrantAsync(MigrantLicenseDto dto)
        {
            using var connection = new SqlConnection(_configuration.GetConnectionString("App1"));
            {
                var parameters = new DynamicParameters();

                parameters.Add("@LicenseNumber", dto.LicenseNumber);
                parameters.Add("@IssuedByOffice", dto.IssuedByOfficeAddress);
                parameters.Add("@NumberOfWorkmen", dto.NumberOfWorkmen);
                parameters.Add("@DepositAmount", dto.DepositAmount);
                parameters.Add("@SecurityDepositPerWorker", dto.SecurityDepositPerWorkmen);
                parameters.Add("@Remark", dto.Remark);

                parameters.Add("@LicenseFromDate", dto.ValidityFrom);
                parameters.Add("@LicenseToDate", dto.ValidityTo);

                parameters.Add("@LicenseToDate", dto.ValidityTo);
                parameters.Add("@IssuedDate", dto.IssuedDate);

                parameters.Add("@CreatedBy", dto.UserId);

                string? filesJson = dto.Files != null && dto.Files.Any()
                    ? JsonSerializer.Serialize(dto.Files)
                    : null;

                parameters.Add("@FilesJson", filesJson);

                var licenseId = await connection.ExecuteScalarAsync<int>(
                    "sp_SaveInterstateMigrant_WithFiles",
                    parameters,
                    commandType: CommandType.StoredProcedure
                );

                return licenseId;
            }
        }
        public async Task<int> SaveFactoryLicense(FactoryLicenseDto dto)
        {
            using var connection = new SqlConnection(_configuration.GetConnectionString("App1"));
            {
                var parameters = new DynamicParameters();

                parameters.Add("@LicenseNumber", dto.LicenseNumber);
                parameters.Add("@IssuedByOffice", dto.IssuedByOfficeAddress);
                parameters.Add("@NumberOfWorkmen", dto.NumberOfWorkmen);
                parameters.Add("@RegistrationNumber", dto.RegistrationNumber);
                parameters.Add("@OccupierName", dto.OccupierName);
                parameters.Add("@DepositAmount", dto.DepositAmount);
                parameters.Add("@SecurityDepositPerWorker", dto.SecurityDepositPerWorkmen);
                parameters.Add("@Remark", dto.Remark);

                parameters.Add("@LicenseFromDate", dto.ValidityFrom);
                parameters.Add("@LicenseToDate", dto.ValidityTo);

                parameters.Add("@IssuedDate", dto.IssuedDate);

                parameters.Add("@CreatedBy", dto.UserId);

                string? filesJson = dto.Files != null && dto.Files.Any()
                    ? JsonSerializer.Serialize(dto.Files)
                    : null;

                parameters.Add("@FilesJson", filesJson);

                var licenseId = await connection.ExecuteScalarAsync<int>(
                    "sp_SaveFactoryLicense_WithFiles",
                    parameters,
                    commandType: CommandType.StoredProcedure
                );

                return licenseId;
            }
        }
        public async Task<List<WageMasterDto>> GeWagMasterDatails()
        {
            using var connection = new SqlConnection(_configuration.GetConnectionString("App1"));

            var  wageMaster = await connection.QueryAsync<WageMasterDto>(
                "sp_GetWageMaster",
                commandType: CommandType.StoredProcedure
            );

            return wageMaster.ToList();
        }
        public async Task<int> SaveWagesMaster(List<WageMasterDto> dto)
        {
            using var connection =
            new SqlConnection(_configuration.GetConnectionString("App1"));

            string json = JsonSerializer.Serialize(dto);

            var parameters = new DynamicParameters();
            parameters.Add("@WagesJson", json);
            parameters.Add("@UserId", "");

            await connection.ExecuteAsync(
                "sp_UpsertWageMaster_BySkill",
                parameters,
                commandType: CommandType.StoredProcedure
            );

            return dto.Count;
        }
    }
}
