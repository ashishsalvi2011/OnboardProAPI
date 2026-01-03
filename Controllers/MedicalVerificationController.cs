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
    public class MedicalVerificationController : ControllerBase
    {
        private readonly IWorkerMedicalVerificationService _service;
        public MedicalVerificationController(IWorkerMedicalVerificationService service)
        {
            _service = service;
        }

        [HttpGet("get")]
        [Authorize]
        public async Task<IActionResult> GetWorkersReadyForMedicalVerification()
        {
            try
            {
                var data = await _service.GetWorkersReadyForMedicalVerificationAsync();
                return Ok(new ListResponseModel<WorkerMedicalVerificationDto>
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
        public async Task<IActionResult> Save([FromBody] WorkerMedicalVerificationRequestDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var newMedicalVerificationId = await _service.SaveMedicalVerificationAsync(dto);
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

        [HttpPost("return-verification")]
        [Authorize]
        public async Task<IActionResult> ReturnWorkerMedicallVerification([FromBody] WorkerMedicalVerificationReturnDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var newMedicalVerificationReturnId = await _service.ReturnWorkerMedicalVerification(dto);
                return Ok(new SingleResponseModel<int>
                {
                    Success = true,
                    Message = newMedicalVerificationReturnId == null
                             ? "Medical Verification return created successfully"
                             : "Medical Verification return updated successfully",
                    Data = newMedicalVerificationReturnId
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
