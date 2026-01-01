using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnboardPro.Interfaces.Services;
using OnboardPro.Models;

namespace OnboardPro.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {

        private readonly IEmployeeService _employeeService;
        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        [HttpGet("draft")]
        [Authorize]
        public async Task<IActionResult> GetDraftWorkers()
        {
            try
            {
                var data = await _employeeService.GetDraftWorkersAsync();
                return Ok(new ListResponseModel<DraftWorkerDto>
                {
                    Success = true,
                    Message = "Draft worker list loaded successfully",
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

        [HttpPost("exit")]
        [Authorize]
        public async Task<IActionResult> ExitWorker([FromBody]  ExitWorkerDto dto)
        {
            try
            {
                var data = await _employeeService.ExitWorkerAsync(dto);
                return Ok(new SingleResponseModel<int>
                {
                    Success = true,
                    Message = "worker Exits successfully",
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

        [HttpGet("onboard")]
        [Authorize]
        public async Task<IActionResult> GetOnboardWorkers()
        {
            try
            {
                var data = await _employeeService.GetOnBoardWorkersAsync();
                return Ok(new ListResponseModel<OnBoardWorkerDto>
                {
                    Success = true,
                    Message = "Onboard worker list loaded successfully",
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

        [HttpGet("id-card")]
        [Authorize]
        public async Task<IActionResult> GetWorkerIdCard()
        {

            try
            {
                var data = await _employeeService.GetIdCardDetails();
                return Ok(new ListResponseModel<WorkerIdCardDto>
                {
                    Success = true,
                    Message = "ID Cards list loaded successfully",
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

        [HttpPost("reward")]
        [Authorize]
        public async Task<IActionResult> WorkerReward([FromBody] WorkerRewardUpsertDto dto)
        {
            try
            {
                var data = await _employeeService.InsertOrUpdateRewardAsync(dto);
                return Ok(new SingleResponseModel<int>
                {
                    Success = true,
                    Message = "Worker Reward saved successfully",
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
