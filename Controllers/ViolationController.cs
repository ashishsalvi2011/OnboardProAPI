using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnboardPro.Interfaces.Services;
using OnboardPro.Models;

namespace OnboardPro.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ViolationController : ControllerBase
    {
        private readonly IViolationService _service;
        public ViolationController(IViolationService service)
        {
            _service = service;
        }

        [HttpGet("get-level")]
        public async Task<IActionResult> GetViolationLevelData()
        {
            try
            { 
                var data = await _service.GetViolationLevelDataAsync();

                return Ok(new ListResponseModel<ViolationLevelDto>
                {
                    Success = true,
                    Message = "Violation Level list loaded successfully",
                    Data = data
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { success = false, message = ex.Message });
            }
            
           
        }

        [HttpPost("save")]
        [Authorize]
        public async Task<IActionResult> Save([FromBody] WorkerViolationUpsertDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var newViolationId = await _service.SaveViolationAsync(dto);
                return Ok(new SingleResponseModel<int>
                {
                    Success = true,
                    Message = newViolationId == null
                             ? "Worker Violation created successfully"
                             : "Worker Violation updated successfully",
                    Data = newViolationId
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

        [HttpGet("get-reasons")]
        public async Task<IActionResult> GetViolationReasonData([FromQuery] int? workerId)
        {
            try
            {
                var data = await _service.GetViolationReasonListAsync(workerId);

                return Ok(new ListResponseModel<WorkerViolationReasonDto>
                {
                    Success = true,
                    Message = "Violation Reason list loaded successfully",
                    Data = data
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { success = false, message = ex.Message });
            }


        }


    }
}
