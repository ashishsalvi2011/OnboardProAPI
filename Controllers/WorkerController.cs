using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnboardPro.Interfaces.Services;
using OnboardPro.Models;

namespace OnboardPro.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WorkerController : ControllerBase
    {
        private readonly IWorkerService _workerService;
        public WorkerController(IWorkerService workerService)
        {
            _workerService = workerService;
        }

        [HttpPost("personal/save")]
        [Authorize]
        public async Task<IActionResult> SaveWorker([FromBody] WorkerDto dto)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                int workerId = await _workerService.InsertOrUpdateWorkerAsync(dto);

                return Ok(new SingleResponseModel<int>
                {
                    Success = true,
                    Message = workerId == null
                             ? "Worker created successfully"
                             : "Worker updated successfully",
                    Data = workerId
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

        [HttpPost("address/save")]
        [Authorize]
        public async Task<IActionResult> SaveWorkerAaddress([FromBody] AddressSaveRequest dto)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                AddressSaveResponse addressSaveResponse = await _workerService.SaveWorkerAddressAsync(dto);

                return Ok(new SingleResponseModel<AddressSaveResponse>
                {
                    Success = true,
                    Message = addressSaveResponse == null
                             ? "Worker Address created successfully"
                             : "Worker Address updated successfully",
                    Data = addressSaveResponse
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

        [HttpPost("contact/save")]
        [Authorize]
        public async Task<IActionResult> SaveWorkerContact([FromBody] WorkerContactDto dto)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                ContactSaveResponse contactSaveResponse = await _workerService.SaveWorkerContactAsync(dto);

                return Ok(new SingleResponseModel<ContactSaveResponse>
                {
                    Success = true,
                    Message = contactSaveResponse == null
                             ? "Worker contact details created successfully"
                             : "Worker contact details updated successfully",
                    Data = contactSaveResponse
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

        [HttpPost("bank/save")]
        [Authorize]
        public async Task<IActionResult> SaveWorkerBank([FromBody] WorkerBankDetailsDto dto)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                int workerId = await _workerService.SaveWorkerBankDetailsAsync(dto);

                return Ok(new SingleResponseModel<int>
                {
                    Success = true,
                    Message = workerId == null
                             ? "Worker Bank Details created successfully"
                             : "Worker Bank Details updated successfully",
                    Data = workerId
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

        [HttpPost("kyc-pf/save")]
        [Authorize]
        public async Task<IActionResult> SaveWorkerKYCOrPF([FromBody] KYCPFSaveRequest dto)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                KYCPFSaveResponse kYCPFSaveResponse = await _workerService.SaveWorkerKYCOrPFAsync(dto);

                return Ok(new SingleResponseModel<KYCPFSaveResponse>
                {
                    Success = true,
                    Message = kYCPFSaveResponse == null
                             ? "Worker KYC or PF created successfully"
                             : "Worker KYC or PF updated successfully",
                    Data = kYCPFSaveResponse
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

        [HttpGet("get")]
        [Authorize]
        public async Task<IActionResult> GetWorkerById([FromQuery] int WorkerId )
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                WorkerDetailsDto worker = await _workerService.GetWorkerById(WorkerId);

                return Ok(new SingleResponseModel<WorkerDetailsDto>
                {
                    Success = true,
                    Message = worker == null
                             ? "Worker created successfully"
                             : "Worker updated successfully",
                    Data = worker
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

