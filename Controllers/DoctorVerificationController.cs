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
    public class DoctorVerificationController : ControllerBase
    {
        private readonly IWorkerDoctorVerificationService _service;
        public DoctorVerificationController(IWorkerDoctorVerificationService service)
        {
            _service = service;
        }

        [HttpGet("all-questions")]
        [Authorize]
        public async Task<IActionResult> GetAllQuestions()
        {
            try
            {
                var data = await _service.GetAllQuestions();
                return Ok(new ListResponseModel<QuestionDto>
                {
                    Success = true,
                    Message = "All Questions list loaded successfully",
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


        [HttpGet("get")]
        [Authorize]
        public async Task<IActionResult> GetWorkersReadyForDoctorVerification()
        {
            try
            {
                var data = await _service.GetWorkersReadyForDoctorVerificationAsync();
                return Ok(new ListResponseModel<WorkerDoctorVerificationDto>
                {
                    Success = true,
                    Message = "worker verification list loaded successfully",
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
        public async Task<IActionResult> Save([FromBody] DoctorVerificationRequestDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var newMedicalVerificationId = await _service.SaveDoctorVerificationAsync(dto);
                return Ok(new SingleResponseModel<int>
                {
                    Success = true,
                    Message = newMedicalVerificationId == null
                             ? "Doctor Verification created successfully"
                             : "Doctor Verification updated successfully",
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
