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
}
