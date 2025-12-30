namespace OnboardPro.Models
{
    public class WorkerPFDto : VerificationDto
    {

    }

    public class WorkerPfEsiUpsertDto
    {
        public int WorkerID { get; set; }
        public string UAN { get; set; }
        public string UniversalAccountName { get; set; }
        public string PFNumber { get; set; }
        public string ESINumber { get; set; }
        public bool IsActive { get; set; }
        public int UserId { get; set; }
    }


}
