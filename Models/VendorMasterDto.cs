namespace OnboardPro.Models
{
    public class VendorMasterDto
    {
        public int VendorId { get; set; }
        public string VendorCode { get; set; }
        public string VendorName { get; set; }
        public int Project { get; set; }
        public bool IsActive { get; set; }
        public string ContactNumber { get; set; }
        public string ContactPerson { get; set; }        
        public string Email { get; set; }
        public string GSTNo { get; set; }
        public string PANNo { get; set; }
        public string TANNo { get; set; }
        public string PFCode { get; set; }
        public string BOCWCode { get; set; }
        public string ISMWCode { get; set; }
        public DateTime? CreatedOn { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public int? UpdatedBy { get; set; }
    }

    public class VendorResponseDto : VendorMasterDto
    {
        public string ProjectName { get; set; }
    }

}
