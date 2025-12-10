namespace OnboardPro.Models
{
    public class MasterDto
    {
    }

    public class GenderDto
    {
        public int? GenderId { get; set; }
        public string GenderName { get; set; }
        public string GenderShortName { get; set; }
        public bool IsActive { get; set; }
    }

}
