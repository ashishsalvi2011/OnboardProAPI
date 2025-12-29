namespace OnboardPro.Models
{
    public class WorkerDoctorVerificationDto: VerificationDto
    {
    }

    public class QuestionDto
    {
        public int QuestionId { get; set; }
        public int TypeId { get; set; }
        public string QuestionText { get; set; }
    }
    public class DoctorVerificationRequestDto
    {
        public int WorkerId { get; set; }
        public DateTime ExaminationDate { get; set; }
        public int UserId { get; set; }
        public List<DoctorQuestionAnswerDto> Questions { get; set; }
    }
    public class DoctorQuestionAnswerDto
    {
        public string QuestionText { get; set; }
        public int TypeId { get; set; }      // 1 = Physical, 2 = History
        public bool Answer { get; set; }     // Yes / No
        public string Remark { get; set; }
    }

}
