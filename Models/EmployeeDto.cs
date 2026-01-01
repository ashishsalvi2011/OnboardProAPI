namespace OnboardPro.Models
{
    public class EmployeeDto
    {
    }
    public class DraftWorkerDto
    {
        public int WorkerId { get; set; }
        public string FullName { get; set; }
        public string MobileNumber { get; set; }

        public int ProjectId { get; set; }
        public string ProjectName { get; set; }

        public int VendorId { get; set; }
        public string VendorName { get; set; }
        public string Status { get; set; }
    }
    public class ExitWorkerDto
    {
        public int WorkerId { get; set; }
        public DateTime ExitDate { get; set; }
        public string ExitReason { get; set; }
        public string? ExitType { get; set; }   // Resignation / Termination
        public int CreatedBy { get; set; }
    }
    public class OnBoardWorkerDto
    {
        public int WorkerID { get; set; }
        public string FullName { get; set; }
        public string MobileNumber { get; set; }

        public int ProjectID { get; set; }
        public string ProjectName { get; set; }

        public int VendorId { get; set; }
        public string VendorName { get; set; }

        public string Status { get; set; }
        public bool IsActive { get; set; }
    }
    public class WorkerIdCardDto
    {
        public int IdCardNo { get; set; }
        public string Name { get; set; }
        public string EmployeeId { get; set; }

        public int ContractorId { get; set; }
        public string ContractorName { get; set; }

        public int ProjectId { get; set; }
        public string ProjectName { get; set; }

        public string Status { get; set; }
        public string Designation { get; set; }

        public decimal? WagesRate { get; set; }
        public string WagesPeriod { get; set; }

        public string Aadhaar { get; set; }
        public string BloodGroup { get; set; }
        public string EmergencyContact { get; set; }
        public string HeightPass { get; set; }

        public string MobileNo { get; set; }
        public DateTime? ValidUpto { get; set; }
        public string MedicallyFit { get; set; }
        public DateTime? SafetyInductionDate { get; set; }

        public string HelplineNo { get; set; }
    }
    public class WorkerRewardUpsertDto
    {
        public int? RewardID { get; set; }   // NULL for insert
        public int WorkerID { get; set; }
        public string RewardReason { get; set; }
        public bool IsActive { get; set; } = true;
        public int UserID { get; set; }
    }


}
