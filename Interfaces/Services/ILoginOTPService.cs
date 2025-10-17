using  OnboardPro.Models;

namespace OnboardPro.Interfaces.Services
{
    public interface ILoginOTPService
    {
        Task<OTPResponse> SendOTPAsync(LoginOTPRequest request);
        Task<VerifyOTPResponse> VerifyOTPAsync(VerifyOTPRequest request);
        Task<UserResponse> GetUserByMobileAsync(string mobileNo);

    }
}
