namespace OnboardPro.Models
{
    public class ViolationDto
    {
    }
    public class ViolationLevelDto
    {
        public int ViolationLevelID { get; set; }
        public string ViolationLevelName { get; set; }
        public string Description { get; set; }
        public int SeverityOrder { get; set; }
    }
    public class WorkerViolationUpsertDto
    {
        public int WorkerID { get; set; }
        public int? ViolationID { get; set; }
        public int ViolationLevelID { get; set; }
        public string ViolationReason { get; set; }
        public bool IsActive { get; set; } = true;
        public int UserID { get; set; }
    }
    public class WorkerViolationReasonDto
    {
        public int ViolationID { get; set; }
        public int WorkerID { get; set; }
        public string ViolationReason { get; set; }
        public string  ViolationLevelName { get; set; }
        public string ViolationLevelDescription { get; set; }
        public string CreatedDate { get; set; }
    }
}
