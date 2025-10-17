namespace OnboardPro.Models
{
    public class LoginOTPRequest
    {
        public string MobileNo { get; set; }
        public int? UserId { get; set; }
        public string? IPAddress { get; set; }
        public string? DeviceInfo { get; set; }
        public string? CreatedBy { get; set; }
    }

    public class VerifyOTPRequest
    {
        public string MobileNo { get; set; }
        public string OTPCode { get; set; }
        public string Username { get; set; }
        public int UserId { get; set; }
        public int RoleId { get; set; }
    }

    public class OTPResponse
    {
        public bool Status { get; set; }
        public string Message { get; set; }
        public string? OTPCode { get; set; }
        public DateTime? OTPExpiryAt { get; set; }
    }

    public class VerifyOTPResponse
    {
        public bool Status { get; set; }
        public string Message { get; set; }
        public string? OTPCode { get; set; }
        public DateTime? OTPExpiryAt { get; set; }
        public string? JwtToken { get; set; }
        public string? Username { get; set; }
        public int? UserId { get; set; }
        public int? RoleId { get; set; }
    }

    public class UserResponse
    {
        public int Success { get; set; }
        public string Message { get; set; }
        public int? UserId { get; set; }
        public string? LoginID { get; set; }
        public string? Name { get; set; }
        public int? ProjectId { get; set; }
        public int? RoleId { get; set; }
        public string? MobileNo { get; set; }
    }
}
