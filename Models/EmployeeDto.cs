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
}
