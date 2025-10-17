using Microsoft.AspNetCore.Mvc;
using OnboardPro.Interfaces.Services;
using OnboardPro.Models;
using Serilog;
using System.Threading.Tasks;

namespace OnboardPro.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LoginOTPController : ControllerBase
    {
        private readonly ILoginOTPService _otpService;
        private readonly JwtService _jwtService;
        public LoginOTPController(ILoginOTPService otpService, JwtService jwtService)
        {
            _otpService = otpService;
            _jwtService = jwtService;
        }

        [HttpPost("send")]
        public async Task<IActionResult> SendOTP([FromBody] LoginOTPRequest request)
        {
            var response = await _otpService.SendOTPAsync(request);
            return Ok(response);
        }

        [HttpPost("verify")]
        public async Task<IActionResult> VerifyOTP([FromBody] VerifyOTPRequest request)
        {
            var response = await _otpService.VerifyOTPAsync(request); 
            if (!response.Status)
            {
                return BadRequest(response);
            }
            var token = _jwtService.GenerateToken(request);
            response.JwtToken = token;
            return Ok(response);
        }

        [HttpGet("get-by-mobile/{mobileNo}")]
        public async Task<IActionResult> GetUserByMobile(string mobileNo)
        {
            if (string.IsNullOrWhiteSpace(mobileNo))
                return BadRequest(new { Success = 0, Message = "Mobile number is required." });

            var response = await _otpService.GetUserByMobileAsync(mobileNo);
            return Ok(response);
        }
    }
}
