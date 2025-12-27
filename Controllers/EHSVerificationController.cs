using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnboardPro.Interfaces.Services;
using OnboardPro.Models;
using OnboardPro.Services;

namespace OnboardPro.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EHSVerificationController : ControllerBase
    {
        private readonly IWorkerEHSVerificationService _service;
        public EHSVerificationController(IWorkerEHSVerificationService service)
        {
            _service = service;
        }

        [HttpGet("get")]
        [Authorize]
        public async Task<IActionResult> GetWorkersReadyForEHSVerification()
        {
            try
            {
                var data = await _service.GetWorkersReadyForEHSVerificationAsync();
                return Ok(new ListResponseModel<EHSVerificationPendingDto>
                {
                    Success = true,
                    Message = "worker EHS verification list loaded successfully",
                    Data = data
                });

            }
            catch (Exception ex)
            {
                return StatusCode(500, new ListResponseModel<string>
                {
                    Success = false,
                    Message = "Internal Server Error: " + ex.Message,
                    Data = null
                });
            }

        }


        [HttpPost("save")]
        [Authorize]
        public async Task<IActionResult> Save([FromBody] EHSVerificationSaveDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var newMedicalVerificationId = await _service.SaveEHSVerificationAsync(dto);
                return Ok(new SingleResponseModel<int>
                {
                    Success = true,
                    Message = newMedicalVerificationId == null
                             ? "Medical Verification created successfully"
                             : "Medical Verification updated successfully",
                    Data = newMedicalVerificationId
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new SingleResponseModel<string>
                {
                    Success = false,
                    Message = ex.Message,
                    Data = null
                });
            }

        }
    }
}
