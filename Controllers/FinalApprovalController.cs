using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnboardPro.Interfaces.Services;
using OnboardPro.Models;

namespace OnboardPro.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FinalApprovalController : ControllerBase
    {
        private readonly IFinalApprovalService _service;
        public FinalApprovalController(IFinalApprovalService service)
        {
            _service = service;
        }

        [HttpGet("get")]
        [Authorize]
        public async Task<IActionResult> GetFinalApprovalReadyWorkers()
        {
            try
            {
                var data = await _service.GetFinalApprovalReadyWorkersAsync();
                return Ok(new ListResponseModel<WorkerFinalApprovalDto>
                {
                    Success = true,
                    Message = "Final Approval worker list loaded successfully",
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

        [HttpPost("approve")]
        [Authorize]
        public async Task<IActionResult> Approve([FromBody] FinalApproveWorkerDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var newMedicalVerificationId = await _service.FinalApproveWorkerAsync(dto);
                return Ok(new SingleResponseModel<int>
                {
                    Success = true,
                    Message = newMedicalVerificationId == null
                             ? "Final approved successfully"
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
