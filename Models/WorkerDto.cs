using System;
using System.ComponentModel.DataAnnotations;

namespace OnboardPro.Models
{
    public class WorkerDto
    {
        public int? WorkerID { get; set; }

        [Required]
        [StringLength(12, MinimumLength = 12)]
        public string AadhaarNumber { get; set; }

        [Required]
        public int ProjectID { get; set; }

        [Required]
        public int VendorId { get; set; }

        [Required]
        [StringLength(100)]
        public string Customer { get; set; }

        [Required]
        [StringLength(100)]
        public string WorkerName { get; set; }

        [StringLength(100)]
        public string? FatherOrSpouseName { get; set; }

        [Required]
        public int GenderId { get; set; }

        [Required]
        public DateTime DateOfBirth { get; set; }

        public int? MaritalStatusId { get; set; }

        [StringLength(100)]
        public string? PlaceOfBirth { get; set; }

        [StringLength(50)]
        public string? MotherTongue { get; set; }

        public int? NationalityId { get; set; }

        [StringLength(10)]
        public string? MobileNumber { get; set; }

        [StringLength(20)]
        public string? TelephoneNumber { get; set; }

        [StringLength(10)]
        public string? SeriousMedicalHistory { get; set; }

        [StringLength(255)]
        public string? IdentificationMark { get; set; }

        [StringLength(255)]
        public string? LanguagesKnown { get; set; }

        [StringLength(50)]
        public string? Religion { get; set; }

        [StringLength(100)]
        public string? Qualification { get; set; }

        [StringLength(10)]
        public string? CrimeGuilty { get; set; }   // Yes / No

        public int? NoOfChildren { get; set; }

        public string? Photograph { get; set; }    // base64 / file path

        public bool IsOnboard { get; set; } = false;

        [StringLength(100)]
        public string? HROnboardedBy { get; set; }

        public DateTime? HROnboardedOn { get; set; }

        [StringLength(255)]
        public string? OnboardRemark { get; set; }

        public bool IsActive { get; set; } = true;

        [Required]
        public string UserID { get; set; }
    }
    public class AddressSaveRequest
    {
        [Required(ErrorMessage = "WorkerID is required")]
        public int WorkerId { get; set; }
        public WorkerAddressDto PresentAddress { get; set; }
        public WorkerAddressDto PermanentAddress { get; set; }

        [Required(ErrorMessage = "UserID is required")]
        public string UserID { get; set; }
    }
    public class WorkerAddressDto
    {
        public int? AddressID { get; set; }

        [StringLength(255)]
        public string? Address1 { get; set; }

        [StringLength(255)]
        public string? Address2 { get; set; }

        [StringLength(255)]
        public string? Address3 { get; set; }

        [StringLength(50)]
        public string? City { get; set; }

        [Required(ErrorMessage = "State is required")]
        public int StateId { get; set; }

        [Required(ErrorMessage = "Country is required")]
        public int CountryId { get; set; }

        [StringLength(10)]
        public string? PinCode { get; set; }

        public bool IsActive { get; set; } = true;

     
    }
    public class AddressSaveResponse
    {
        public int PresentAddressId { get; set; }
        public int PermanentAddressId { get; set; }
    }
    public class WorkerContactDto
    {
        public int? ContactID { get; set; }
        public int WorkerID { get; set; }
        public bool IsActive { get; set; } = true;
        public string UserID { get; set; } = string.Empty;
        public string? ContactName { get; set; }
        public int? ContactRelationId { get; set; }
        public string? ContactMobile { get; set; }
        public string? ContactAddress { get; set; }

        public int? NomineeID { get; set; }
        public bool? NomineeSameAsContact { get; set; } = false;
        public bool? NomineeAddressSameAsContact { get; set; } = false;
        public int? NomineeRelationId { get; set; }
        public string? NomineeName { get; set; }
        public string? NomineeAddress { get; set; }
        public string? NomineeMobile { get; set; }
        public DateTime? NomineeDateOfBirth { get; set; }
    }
    public class ContactSaveResponse
    {
        public int ContactId { get; set; }
        public int NomineeId { get; set; }
    }
    public class WorkerBankDetailsDto
    {
        public int? BankID { get; set; }

        [Required(ErrorMessage = "WorkerID is required")]
        public int WorkerID { get; set; }

        [Required, StringLength(100)]
        public string AccountHolderName { get; set; }

        [Required, StringLength(50)]
        public string AccountNumber { get; set; }

        [Required, StringLength(20)]
        public string IFSCCode { get; set; }

        [Required, StringLength(100)]
        public string BankName { get; set; }

        [Required, StringLength(100)]
        public string BranchName { get; set; }

        [StringLength(255)]
        public string? BranchAddress { get; set; }

        [StringLength(10)]
        public string? PostalCode { get; set; }

        [StringLength(50)]
        public string? City { get; set; }

        [Required(ErrorMessage = "State is required")]
        public int StateId { get; set; }

        [Required(ErrorMessage = "Country is required")]
        public int CountryId { get; set; }

        public bool IsActive { get; set; } = true;

        [Required(ErrorMessage = "UserID is required")]
        public string UserID { get; set; }
    }
    public class KYCPFSaveRequest
    {
        [Required(ErrorMessage = "WorkerID is required")]
        public int WorkerId { get; set; }
        public WorkerKYCDto Kyc { get; set; }
        public WorkerPFESIDto Pf { get; set; }

        [Required(ErrorMessage = "UserID is required")]
        public string UserID { get; set; }
    }
    public class WorkerKYCDto
    {
            public int? KYCID { get; set; }

            [StringLength(20)]
            public string? PANNumber { get; set; }

            [StringLength(20)]
            public string? VoterID { get; set; }

            [StringLength(20)]
            public string? NationalPopulationRegistration { get; set; }

            [StringLength(20)]
            public string? BocwNumber { get; set; }

            [StringLength(20)]
            public string? DriversLicense { get; set; }

            [StringLength(20)]
            public string? PassportNumber { get; set; }

            public bool IsActive { get; set; } = true;

    }
    public class WorkerPFESIDto
    {
        public int? PFID { get; set; }

        [StringLength(50)]
        public string? UAN { get; set; }

        [StringLength(100)]
        public string? UniversalAccountName { get; set; }

        [StringLength(50)]
        public string? PFNumber { get; set; }

        [StringLength(50)]
        public string? ESINumber { get; set; }

        public string? Signature { get; set; }

        public bool IsActive { get; set; } = true;

    }
    public class KYCPFSaveResponse
    {
        public int KycId { get; set; }
        public int PfId { get; set; }
    }
    public class WorkerDetailsDto
    {
        public WorkerDto PersonalDetails { get; set; }
        public WorkerAddressDto PresentAddress { get; set; }
        public WorkerAddressDto PermanentAddress { get; set; }
        public WorkerContactDto EmergencyContact { get; set; }
        public WorkerContactDto Nominee { get; set; }
        public WorkerBankDetailsDto BankDetails { get; set; }
        public WorkerKYCDto KycDetails { get; set; }
        public WorkerPFESIDto PfInsurance { get; set; }
    }
}
