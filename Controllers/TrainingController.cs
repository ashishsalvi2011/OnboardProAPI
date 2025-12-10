using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnboardPro.Interfaces.Services;
using OnboardPro.Models;

namespace OnboardPro.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrainingController : ControllerBase
    {
        private readonly ITrainingService _service;

        public TrainingController(ITrainingService service)
        {
            _service = service;
        }


        [HttpGet("status-list")]
        [Authorize]
        public async Task<IActionResult> GetStatusList()
        {
            try
            {
                var data = await _service.GetStatusList();
                return Ok(new ListResponseModel<TrainingStatusDto>
                {
                    Success = true,
                    Message = "Status list loaded successfully",
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

        [HttpGet("duration-list")]
        [Authorize]
        public async Task<IActionResult> GetDurationList()
        {
            try
            {
                var data = await _service.GetDurationList();
                return Ok(new ListResponseModel<TrainingDurationDto>
                {
                    Success = true,
                    Message = "Duration list loaded successfully",
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
        public async Task<IActionResult> SaveTraining([FromBody] TrainingMasterDto user)
        {
            try
            {
                var newUserId = await _service.SaveTrainingAsync(user);
                return Ok(new SingleResponseModel<int>
                {
                    Success = true,
                    Message = newUserId == null
                         ? "Training created successfully"
                         : "Training updated successfully",
                    Data = newUserId
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

        [HttpGet("trainings")]
        [Authorize]
        public async Task<IActionResult> GetTraining()
        {
            try
            {
                var data = await _service.GetTrainingAsync();
                return Ok(new ListResponseModel<TrainingMasterResponseDto>
                {
                    Success = true,
                    Message = "Training list loaded successfully",
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
    }
}
