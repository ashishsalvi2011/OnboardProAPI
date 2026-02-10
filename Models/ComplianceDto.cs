namespace OnboardPro.Models
{
    public class ComplianceDto
    {
    }
    public class ContractLabourLicenseDto
    {
        public string LicenseNumber { get; set; }
        public int NumberOfWorkmen { get; set; }
        public decimal SecurityDepositPerWorkmen { get; set; }
        public decimal DepositAmount { get; set; }
        public DateTime ValidityFrom { get; set; }
        public DateTime ValidityTo { get; set; }
        public DateTime IssuedDate { get; set; }
        public string IssuedByOfficeAddress { get; set; }
        public string Remark { get; set; }
        public string UserId { get; set; }  
        public List<FileBase64Dto> Files { get; set; }
    }
    public class BOCWLicenseDto
    {
        public string LicenseNumber { get; set; }
        public int NumberOfWorkmen { get; set; }
        public decimal SecurityDepositPerWorkmen { get; set; }
        public decimal DepositAmount { get; set; }
        public DateTime ValidityFrom { get; set; }
        public DateTime ValidityTo { get; set; }
        public DateTime IssuedDate { get; set; }
        public string IssuedByOfficeAddress { get; set; }
        public string Remark { get; set; }
        public string UserId { get; set; }
        public List<FileBase64Dto> Files { get; set; }
    }
    public class MigrantLicenseDto
    {
        public string LicenseNumber { get; set; }
        public int NumberOfWorkmen { get; set; }
        public decimal SecurityDepositPerWorkmen { get; set; }
        public decimal DepositAmount { get; set; }
        public DateTime ValidityFrom { get; set; }
        public DateTime ValidityTo { get; set; }
        public DateTime IssuedDate { get; set; }
        public string IssuedByOfficeAddress { get; set; }
        public string Remark { get; set; }
        public string UserId { get; set; }
        public List<FileBase64Dto> Files { get; set; }
    }
    public class FactoryLicenseDto
    {
        public string LicenseNumber { get; set; }
        public string RegistrationNumber { get; set; }
        public string OccupierName { get; set; }
        public int NumberOfWorkmen { get; set; }
        public decimal SecurityDepositPerWorkmen { get; set; }
        public decimal DepositAmount { get; set; }
        public DateTime ValidityFrom { get; set; }
        public DateTime ValidityTo { get; set; }
        public DateTime IssuedDate { get; set; }
        public string IssuedByOfficeAddress { get; set; }
        public string Remark { get; set; }
        public string UserId { get; set; }
        public List<FileBase64Dto> Files { get; set; }
    }
    public class FileBase64Dto
    {
        public string FileName { get; set; }
        public string FileType { get; set; }
        public long FileSize { get; set; }
        public string Base64Data { get; set; }
    }
    public class WageMasterDto
    {
        public int WageMasterId { get; set; }
        public int SkillCategoryID { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
        public decimal DailyWage { get; set; }
        public decimal OvertimeRate { get; set; }
        public bool IsActive { get; set; }
    }

}
