using OnboardPro.Interfaces.Services;
using OnboardPro.Interfaces.Repositories;
using OnboardPro.Models;
using System.Threading.Tasks;

namespace OnboardPro.Services
{
    public class LoginOTPService : ILoginOTPService
    {
        private readonly ILoginOTPRepository _repository;

        public LoginOTPService(ILoginOTPRepository repository)
        {
            _repository = repository;
        }

        public async Task<OTPResponse> SendOTPAsync(LoginOTPRequest request)
        {
            return await _repository.SendOTPAsync(request);
        }

        public async Task<VerifyOTPResponse> VerifyOTPAsync(VerifyOTPRequest request)
        {
            return await _repository.VerifyOTPAsync(request);
        }


        public async Task<UserResponse> GetUserByMobileAsync(string mobileNo)
        {
            return await _repository.GetUserByMobileAsync(mobileNo);
        }
    }

}
