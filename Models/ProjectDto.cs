namespace OnboardPro.Models
{
    public class ProjectDto
    {
        public int? ProjectId { get; set; }
        public string ProjectName { get; set; }
        public string ProjectCode { get; set; }
        public int CompanyId { get; set; }
        public string? Location { get; set; }
        public string? CustomerName { get; set; }
        public string? HelplineNumber { get; set; }
        public bool IsActive { get; set; } = true;
        public string UserId { get; set; }
    }

    public class ProjectListDto
    {
        public int ProjectId { get; set; }
        public string ProjectName { get; set; }
        public string ProjectCode { get; set; }
        public string Location { get; set; }
        public string Customer { get; set; }
        public string HelplineNumber { get; set; }
        public string Status { get; set; }
        public bool IsActive { get; set; }
    }

}
