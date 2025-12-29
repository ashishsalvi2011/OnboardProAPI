namespace OnboardPro.Models
{
    public class EHSVerificationPendingDto
    {
        public int WorkerID { get; set; }
        public string FullName { get; set; }
        public string MobileNumber { get; set; }

        public int ProjectID { get; set; }
        public string ProjectName { get; set; }

        public int? VendorId { get; set; }
        public string VendorName { get; set; }

        public int? SkillVerificationUserId { get; set; }
        public string SkillVerificationBy { get; set; }

        public int? MedicalVerificationUserId { get; set; }
        public string MedicalVerificationBy { get; set; }

        public int WorkerCreatedUserId { get; set; }
        public string WorkerCreatedBy { get; set; }

        public string Status { get; set; }
    }
    public class EHSVerificationSaveDto
    {
        public int? EHSVerificationID { get; set; }   // null = insert
        public int WorkerID { get; set; }
        public int? VendorID { get; set; }

        public int? EhsInchargeId { get; set; }
        public decimal? HeightTest { get; set; }

        public int? MedicalVerifiedById { get; set; }
        public int? DoctorVerificationDoneBy { get; set; } = 0;
        public int? WorkforceCreatedById { get; set; }
        public int? SkillVerifiedById { get; set; }

        public DateTime? SafetyInductionDate { get; set; }
        public string? Remarks { get; set; }

        public bool IsActive { get; set; } = true;

        public string UserID { get; set; } = string.Empty; // logged-in user
    }

}
