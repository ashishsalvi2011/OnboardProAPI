using System.ComponentModel.DataAnnotations;

namespace OnboardPro.Models
{

    public class WorkerMedicalVerificationDto: VerificationDto
    {            
    }

    public class WorkerMedicalVerificationRequestDto
    {
        public int VerificationID { get; set; }  

        public int WorkerID { get; set; }

        public DateTime HealthCheckupDate { get; set; }

        public decimal? Pulse { get; set; }

        public decimal? SPO2 { get; set; }

        public int? Rr { get; set; }

        public decimal? SkinTemp { get; set; }

        public int? BpSystolic { get; set; }

        public int? Diastolic { get; set; }

        public decimal? Sugar { get; set; }

        public decimal? Weight { get; set; }

        public decimal? Height { get; set; }

        public decimal? BMI { get; set; }

        public string? BloodGroup { get; set; }

        [Required]
        public bool IsVerify { get; set; }
        public int CreatedBy { get; set; }
    }

}
