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
    public class PFController : ControllerBase
    {
        private readonly IWorkerPFService _service;
        public PFController(IWorkerPFService service)
        {
            _service = service;
        }

        [HttpGet("get")]
        [Authorize]
        public async Task<IActionResult> GetWorkerListForPFDetails()
        {
            try
            {
                var data = await _service.GetWorkersDeatilsForPFAsync();
                return Ok(new ListResponseModel<WorkerPFDto>
                {
                    Success = true,
                    Message = "PF worker list loaded successfully",
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
        public async Task<IActionResult> Save([FromBody] WorkerPfEsiUpsertDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var newMedicalVerificationId = await _service.SavePFAsync(dto);
                return Ok(new SingleResponseModel<int>
                {
                    Success = true,
                    Message = newMedicalVerificationId == null
                             ? "PF created successfully"
                             : "PF updated successfully",
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
    