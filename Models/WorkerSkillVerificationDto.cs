using System.ComponentModel.DataAnnotations;

namespace OnboardPro.Models
{
    public class VerificationDto
    {
        public int WorkerId { get; set; }
        public string FullName { get; set; }
        public string MobileNumber { get; set; }

        public int? ProjectId { get; set; }
        public string ProjectName { get; set; }

        public int? VendorId { get; set; }
        public string VendorName { get; set; }

        public string Status { get; set; }
    }
    public class WorkerSkillVerificationDto: VerificationDto
    {
    }
    public class SkillProficiencyDto
    {
        public int ProficiencyId { get; set; }
        public string ProficiencyName { get; set; }
    }
    public class SkillAndProficiencyResponseDto
    {
        public List<SkillDto> Skills { get; set; }
        public List<SkillProficiencyDto> Proficiencies { get; set; }
    }
    public class WorkerSkillVerificationSubmitDto
    {
        public int VerificationId { get; set; }
        
        [Required]
        public int WorkerId { get; set; }
        public int SkillGroupId { get; set; }
        public int SkillSubGroupId { get; set; }

        [Required]
        public int SkillId { get; set; }

        [Required]
        public int ProficiencyId { get; set; }

        [Required]
        public bool IsVerify { get; set; }
        public int CreatedBy { get; set; }
    }
    public class WorkerSkillVerificationReturnDto
    {
        public int VerificationId { get; set; }
        public int WorkerId { get; set; }
        public int SkillId { get; set; }
        public string ReturnReason { get; set; } = string.Empty; 
        public int UserId { get; set; }
    }

}
