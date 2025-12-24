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
    public class SkillVerificationController : ControllerBase
    {
        private readonly IWorkerSkillVerificationService _service;
        public SkillVerificationController( IWorkerSkillVerificationService service)
        {
            _service = service;
        }

        [HttpGet("get")]
        [Authorize]
        public async Task<IActionResult> GetWorkersReadyForSkillVerification()
        {
            try
            {
                var data = await _service.GetWorkersReadyForSkillVerificationAsync();
                return Ok(new ListResponseModel<WorkerSkillVerificationDto>
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

        [HttpGet("skill-and-proficiency")]
        [Authorize]
        public async Task<IActionResult> GetSkillAndProficiency()
        {
            try
            {
                var data = await _service.GetSkillAndProficiencyAsync();
                return Ok(new SingleResponseModel<SkillAndProficiencyResponseDto>
                {
                    Success = true,
                    Message = "worker verification list loaded successfully",
                    Data = data
                });

            }
            catch (Exception ex)
            {
                return StatusCode(500, new SingleResponseModel<string>
                {
                    Success = false,
                    Message = "Internal Server Error: " + ex.Message,
                    Data = null
                });
            }
        }

        [HttpPost("save")]
        [Authorize]
        public async Task<IActionResult> Save([FromBody] WorkerSkillVerificationSubmitDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var newSkillVerificationId = await _service.SaveSkillVerificationAsync(dto);
                return Ok(new SingleResponseModel<int>
                {
                    Success = true,
                    Message = newSkillVerificationId == null
                             ? "Skill Verification created successfully"
                             : "Skill Verification updated successfully",
                    Data = newSkillVerificationId
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
