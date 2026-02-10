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
        public async Task<IActionResult> GetDraftWorkers(int userId)
        {
            try
            {
                var data = await _employeeService.GetDraftWorkersAsync(userId);
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

        [HttpGet("worker-for-exit")]
        [Authorize]
        public async Task<IActionResult> GetWorkersForExit(int userId)
        {
            try
            {
                var data = await _employeeService.GetWorkersForExit(userId);
                return Ok(new ListResponseModel<OnBoardWorkerDto>
                {
                    Success = true,
                    Message = "exit worker for exit list loaded successfully",
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
        public async Task<IActionResult> GetOnboardWorkers(int userId)
        {
            try
            {
                var data = await _employeeService.GetOnBoardWorkersAsync(userId);
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
        public async Task<IActionResult> GetWorkerIdCard(int userId)
        {

            try
            {
                var data = await _employeeService.GetIdCardDetails(userId);
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

        [HttpPost("block-unblock")]
        [Authorize]
        public async Task<IActionResult> BlockOrUnblockWorker([FromBody] WorkerBlockRequestDto dto)
        {
            try
            {
                var data = await _employeeService.BlockOrUnblockWorkerAsync(dto);
                return Ok(new SingleResponseModel<int>
                {
                    Success = true,
                    Message = "worker " + dto.Action + " successfully",
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

        [HttpGet("returned-workers")]
        [Authorize]
        public async Task<IActionResult> GetReturnedWorkersAsync(int userId)
        {
            try
            {
                var data = await _employeeService.GetReturnedWorkersAsync(userId);
                return Ok(new ListResponseModel<ReturnedWorkerDto>
                {
                    Success = true,
                    Message = "Returned worker list loaded successfully",
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

        [HttpPost("update-gate-pass")]
        [Authorize]
        public async Task<IActionResult> UpdateWokerGatePassDetails([FromBody] WorkerWageDto dto)
        {
            try
            {
                var data = await _employeeService.UpdateWokerGatePassDetails(dto);
                return Ok(new SingleResponseModel<int>
                {
                    Success = true,
                    Message = "Updated worker gate pass details successfully",
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
