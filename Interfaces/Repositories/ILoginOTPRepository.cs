using OnboardPro.Models;

namespace OnboardPro.Interfaces.Repositories
{
    public interface ILoginOTPRepository
    {
        Task<OTPResponse> SendOTPAsync(LoginOTPRequest request);
        Task<VerifyOTPResponse> VerifyOTPAsync(VerifyOTPRequest request);
        Task<UserResponse> GetUserByMobileAsync(string mobileNo);
    }    
}
