namespace OnboardPro.Models
{
    public class TrainingMasterDto
    {
        public int TrainingId { get; set; }
        public string TopicName { get; set; }
        public DateTime TrainingDate { get; set; }
        public string ImpartedBy { get; set; }
        public int Duration { get; set; }
        public int Status { get; set; }
        public string Description { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
    }

    public class TrainingMasterResponseDto
    {
        public int TrainingId { get; set; }
        public string TopicName { get; set; }
        public DateTime TrainingDate { get; set; }
        public string ImpartedBy { get; set; }
        public int DurationId { get; set; }
        public int StatusId { get; set; }
        public string Duration { get; set; }
        public string Status { get; set; }
        public string Description { get; set; }
    }

    public class TrainingStatusDto
    {
        public int StatusId { get; set; }
        public string StatusName { get; set; }
    }
    public class TrainingDurationDto
    {
        public int DurationId { get; set; }
        public string DurationName { get; set; }
    }

}
