namespace OnboardPro.Models
{
    public class WorkerFinalApprovalDto
    {
        public int WorkerID { get; set; }
        public string FullName { get; set; } = string.Empty;
        public string MobileNumber { get; set; } = string.Empty;

        public int ProjectID { get; set; }
        public string ProjectName { get; set; } = string.Empty;

        public int? VendorId { get; set; }
        public string? VendorName { get; set; }

        public string Status { get; set; } = string.Empty;
    }

    public class FinalApproveWorkerDto
    {
        public int WorkerID { get; set; }
        public bool IsOnboard { get; set; } = true;
        public int HROnboardedBy { get; set; } 
        public string? OnboardRemark { get; set; }
    }

}
