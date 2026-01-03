namespace OnboardPro.Models
{
    public class WorkerBlockRequestDto
    {
        public int WorkerId { get; set; }
        public string Action { get; set; } = string.Empty;
        public string? Reason { get; set; }
        public int UserId { get; set; }
    }
}
