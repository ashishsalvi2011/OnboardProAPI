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
        public int VerificationID { get; set; }
        public int WorkerId { get; set; }
        public int UserId { get; set; }
        public string PrescriptionAttached { get; set; }
        public List<DoctorQuestionAnswerDto> Questions { get; set; }
    }
    public class DoctorQuestionAnswerDto
    {
        public int QuestionId { get; set; }
        public int TypeId { get; set; }
        public bool Answer { get; set; }
        public string Remark { get; set; }
    }

}
