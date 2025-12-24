namespace OnboardPro.Models
{
    public class MasterDto
    {
        public string Type { get; set; }
        public int Id { get; set; }
        public string Name { get; set; }
    }
    public class GenderDto
    {
        public int? GenderId { get; set; }
        public string GenderName { get; set; }
        public string GenderShortName { get; set; }
        public bool IsActive { get; set; }
    }

}
