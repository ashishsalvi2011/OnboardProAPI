using Dapper;
using Microsoft.Data.SqlClient;
using OnboardPro.Interfaces.Repositories;
using OnboardPro.Models;
using System.Data;
using System.Net;

namespace OnboardPro.Repositories
{
    public class WorkerRepository:IWorkerRepository
    {
        private readonly IConfiguration _configuration;
        public WorkerRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public async Task<int> InsertOrUpdateWorkerAsync(WorkerDto worker)
        {
            using var connection =
                new SqlConnection(_configuration.GetConnectionString("App1"));

            var parameters = new DynamicParameters();

            parameters.Add("@WorkerID", worker.WorkerID);
            parameters.Add("@AadhaarNumber", worker.AadhaarNumber);
            parameters.Add("@ProjectID", worker.ProjectID);
            parameters.Add("@VendorId", worker.VendorId);
            parameters.Add("@Customer", worker.Customer);

            parameters.Add("@FullName", worker.WorkerName);
            parameters.Add("@FatherOrSpouseName", worker.FatherOrSpouseName);
            parameters.Add("@GenderId", worker.GenderId);
            parameters.Add("@DateOfBirth", worker.DateOfBirth);
            parameters.Add("@MaritalStatusId", worker.MaritalStatusId);

            parameters.Add("@PlaceOfBirth", worker.PlaceOfBirth);
            parameters.Add("@MotherTongue", worker.MotherTongue);
            parameters.Add("@NationalityId", worker.NationalityId);

            parameters.Add("@MobileNumber", worker.MobileNumber);
            parameters.Add("@TelephoneNumber", worker.TelephoneNumber);

            parameters.Add("@SeriousMedicalHistory", worker.SeriousMedicalHistory);
            parameters.Add("@IdentificationMark", worker.IdentificationMark);
            parameters.Add("@LanguagesKnown", worker.LanguagesKnown);
            parameters.Add("@Religion", worker.Religion);
            parameters.Add("@Qualification", worker.Qualification);
            parameters.Add("@CrimeGuilty", worker.CrimeGuilty);
            parameters.Add("@NoOfChildren", worker.NoOfChildren);

            parameters.Add("@Photograph", worker.Photograph);

            parameters.Add("@IsOnboard", worker.IsOnboard);
            parameters.Add("@HROnboardedBy", worker.HROnboardedBy);
            parameters.Add("@HROnboardedOn", worker.HROnboardedOn);
            parameters.Add("@OnboardRemark", worker.OnboardRemark);

            parameters.Add("@IsActive", worker.IsActive);
            parameters.Add("@UserID", worker.UserID);

            var result = await connection.QueryFirstOrDefaultAsync<int>(
                "sp_InsertOrUpdateWorker",
                parameters,
                commandType: CommandType.StoredProcedure
            );

            return result;
        }
        public async Task<AddressSaveResponse> InsertOrUpdateWorkerAddressAsync(AddressSaveRequest address)
        {
            using var connection =
                new SqlConnection(_configuration.GetConnectionString("App1"));

            await connection.OpenAsync();

            using var transaction = connection.BeginTransaction();

            try
            {
                // 🔹 Present Address
                var presentParams = new DynamicParameters();
                presentParams.Add("@AddressID", address.PresentAddress.AddressID);
                presentParams.Add("@WorkerID", address.WorkerId);
                presentParams.Add("@Address1", address.PresentAddress.Address1);
                presentParams.Add("@Address2", address.PresentAddress.Address2);
                presentParams.Add("@Address3", address.PresentAddress.Address3);
                presentParams.Add("@City", address.PresentAddress.City);
                presentParams.Add("@StateId", address.PresentAddress.StateId);
                presentParams.Add("@CountryId", address.PresentAddress.CountryId);
                presentParams.Add("@PinCode", address.PresentAddress.PinCode);
                presentParams.Add("@IsActive", address.PresentAddress.IsActive);
                presentParams.Add("@UserID", address.UserID);

                var presentAddressId = await connection.QueryFirstAsync<int>(
                    "sp_InsertOrUpdateWorkerAddress",
                    presentParams,
                    transaction,
                    commandType: CommandType.StoredProcedure
                );

                var permanentParams = new DynamicParameters();
                permanentParams.Add("@AddressID", address.PermanentAddress.AddressID);
                permanentParams.Add("@WorkerID", address.WorkerId);
                permanentParams.Add("@Address1", address.PermanentAddress.Address1);
                permanentParams.Add("@Address2", address.PermanentAddress.Address2);
                permanentParams.Add("@Address3", address.PermanentAddress.Address3);
                permanentParams.Add("@City", address.PermanentAddress.City);
                permanentParams.Add("@StateId", address.PermanentAddress.StateId);
                permanentParams.Add("@CountryId", address.PermanentAddress.CountryId);
                permanentParams.Add("@PinCode", address.PermanentAddress.PinCode);
                permanentParams.Add("@IsActive", address.PermanentAddress.IsActive);
                permanentParams.Add("@UserID", address.UserID);

                var permanentAddressId = await connection.QueryFirstAsync<int>(
                    "sp_InsertOrUpdateWorkerPermanentAddress",
                    permanentParams,
                    transaction,
                    commandType: CommandType.StoredProcedure
                );

                await transaction.CommitAsync();

                return new AddressSaveResponse
                {
                    PresentAddressId = presentAddressId,
                    PermanentAddressId = permanentAddressId
                };
            }
            catch
            {
                await transaction.RollbackAsync();
                throw;
            }
        }
        public async Task<ContactSaveResponse> InsertOrUpdateWorkerContactAsync(WorkerContactDto contact)
        {
            using var connection =
                new SqlConnection(_configuration.GetConnectionString("App1"));

            await connection.OpenAsync();

            using var transaction = connection.BeginTransaction();

            try
            {
                var contactParams = new DynamicParameters();
                contactParams.Add("@ContactID", contact.ContactID);
                contactParams.Add("@WorkerID", contact.WorkerID);
                contactParams.Add("@ContactName", contact.ContactName);
                contactParams.Add("@RelationId", contact.ContactRelationId);
                contactParams.Add("@MobileNumber", contact.ContactMobile);
                contactParams.Add("@Address", contact.ContactAddress);
                contactParams.Add("@IsActive", contact.IsActive);
                contactParams.Add("@UserID", contact.UserID);

                var contactId = await connection.QueryFirstAsync<int>(
                    "sp_InsertOrUpdateWorkerEmergencyContact",
                    contactParams,
                    transaction,
                    commandType: CommandType.StoredProcedure
                );

                var nomineeParams = new DynamicParameters();
                nomineeParams.Add("@NomineeID", contact.NomineeID);
                nomineeParams.Add("@WorkerID", contact.WorkerID);
                nomineeParams.Add("@SameAsEmergencyContact", contact.NomineeAddressSameAsContact ?? false);
                nomineeParams.Add("@SameAddressAsContact", contact.NomineeAddressSameAsContact ?? false);
                nomineeParams.Add("@NomineeName", contact.NomineeName);
                nomineeParams.Add("@RelationId", contact.NomineeRelationId);
                nomineeParams.Add("@NomineeAddress", contact.NomineeAddress);
                nomineeParams.Add("@NomineeMobileNumber", contact.NomineeMobile);
                nomineeParams.Add("@NomineeDateOfBirth", contact.NomineeDateOfBirth);
                nomineeParams.Add("@IsActive", contact.IsActive);
                nomineeParams.Add("@UserID", contact.UserID);

                var nomineeId = await connection.QueryFirstAsync<int>(
                    "sp_InsertOrUpdateWorkerNominee",
                    nomineeParams,
                    transaction,
                    commandType: CommandType.StoredProcedure
                );

                await transaction.CommitAsync();

                return new ContactSaveResponse
                {
                    ContactId = contactId,
                    NomineeId = nomineeId
                };
            }
            catch
            {
                await transaction.RollbackAsync();
                throw;
            }
        }
        public async Task<int> InsertOrUpdateWorkerBankDetailsAsync(WorkerBankDetailsDto bank)
        {
            using var connection =
                new SqlConnection(_configuration.GetConnectionString("App1"));

            var parameters = new DynamicParameters();

            parameters.Add("@BankID", bank.BankID);
            parameters.Add("@WorkerID", bank.WorkerID);
            parameters.Add("@AccountHolderName", bank.AccountHolderName);
            parameters.Add("@AccountNumber", bank.AccountNumber);
            parameters.Add("@IFSCCode", bank.IFSCCode);
            parameters.Add("@BankName", bank.BankName);
            parameters.Add("@BranchName", bank.BranchName);
            parameters.Add("@BranchAddress", bank.BranchAddress);
            parameters.Add("@PostalCode", bank.PostalCode);
            parameters.Add("@City", bank.City);
            parameters.Add("@StateId", bank.StateId);
            parameters.Add("@CountryId", bank.CountryId);
            parameters.Add("@IsActive", bank.IsActive);
            parameters.Add("@UserID", bank.UserID);

            var result = await connection.QueryFirstOrDefaultAsync<int>(
                "sp_InsertOrUpdateWorkerBankDetails",
                parameters,
                commandType: CommandType.StoredProcedure
            );

            return result;
        }
        public async Task<KYCPFSaveResponse> InsertOrUpdateWorkerKYCOrPFAsync(KYCPFSaveRequest kycPf)
        {
            using var connection =
                new SqlConnection(_configuration.GetConnectionString("App1"));

            await connection.OpenAsync();
            using var transaction = connection.BeginTransaction();

            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("@KYCID", kycPf.Kyc.KYCID);
                parameters.Add("@WorkerID", kycPf.WorkerId);
                parameters.Add("@PANNumber", kycPf.Kyc.PANNumber);
                parameters.Add("@VoterID", kycPf.Kyc.VoterID);
                parameters.Add("@NationalPopulationRegistration", kycPf.Kyc.NationalPopulationRegistration);
                parameters.Add("@BocwNumber", kycPf.Kyc.BocwNumber);
                parameters.Add("@DrivingLicense", kycPf.Kyc.DriversLicense);
                parameters.Add("@PassportNumber", kycPf.Kyc.PassportNumber);
                parameters.Add("@IsActive", kycPf.Kyc.IsActive);
                parameters.Add("@UserID", kycPf.UserID);

                var kycId = await connection.QueryFirstAsync<int>(
                    "sp_InsertOrUpdateWorkerKYC",
                    parameters,
                    transaction,
                    commandType: CommandType.StoredProcedure
                );

                var parameterspf = new DynamicParameters();
                parameterspf.Add("@PFID", kycPf.Pf.PFID);
                parameterspf.Add("@WorkerID", kycPf.WorkerId);
                parameterspf.Add("@UAN", kycPf.Pf.UAN);
                parameterspf.Add("@UniversalAccountName", kycPf.Pf.UniversalAccountName);
                parameterspf.Add("@PFNumber", kycPf.Pf.PFNumber);
                parameterspf.Add("@ESINumber", kycPf.Pf.ESINumber);
                parameterspf.Add("@IsActive", kycPf.Pf.IsActive);
                parameterspf.Add("@UserID", kycPf.UserID);

                var pfId = await connection.QueryFirstAsync<int>(
                    "sp_InsertOrUpdateWorkerPF_ESI",
                    parameterspf,
                    transaction,
                    commandType: CommandType.StoredProcedure
                );


                await transaction.CommitAsync();

                return new KYCPFSaveResponse
                {
                    KycId = kycId,
                    PfId = pfId
                };
            }
            catch
            {
                await transaction.RollbackAsync();
                throw;
            }





        
        }
        public async Task<WorkerDetailsDto> GetWorkerFullDetail(int workerId)
        {
            using var connection = new SqlConnection(_configuration.GetConnectionString("App1"));
            {
                var parameters = new DynamicParameters();
                parameters.Add("@WorkerId", workerId);

                var multi = await connection.QueryMultipleAsync(
                    "sp_GetWorkerFullDetails",
                    parameters,
                    commandType: CommandType.StoredProcedure
                );

                var worker = multi.ReadSingleOrDefault<WorkerDto>();
                var addresses = multi.ReadSingleOrDefault<WorkerAddressDto>();
                var paddresses = multi.ReadSingleOrDefault<WorkerAddressDto>();
                var emergency = multi.ReadSingleOrDefault<WorkerContactDto>();
                //var nominee = multi.ReadSingleOrDefault<WorkerContactDto>();
                var bank = multi.ReadSingleOrDefault<WorkerBankDetailsDto>();
                var kyc = multi.ReadSingleOrDefault<WorkerKYCDto>();
                var pf = multi.ReadSingleOrDefault<WorkerPFESIDto>();

                return new WorkerDetailsDto
                {
                    PersonalDetails = worker,
                    PresentAddress = addresses,
                    PermanentAddress = paddresses,
                    EmergencyContact = emergency,
                    //Nominee = nominee,
                    BankDetails = bank,
                    KycDetails = kyc,
                    PfInsurance = pf
                };
            }
        }
        
    }
}
