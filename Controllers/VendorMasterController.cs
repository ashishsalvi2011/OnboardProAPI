using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnboardPro.Interfaces.Services;
using OnboardPro.Models;

namespace OnboardPro.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VendorMasterController : ControllerBase
    {
        private readonly IVendorMasterService _service;

        public VendorMasterController(IVendorMasterService service)
        {
            _service = service;
        }

        [HttpPost("save")]
        [Authorize]
        public async Task<IActionResult> SaveVendor([FromBody] VendorMasterDto vendor)
        {
            try
            {
                var newUserId = await _service.SaveVendorAsync(vendor);
                return Ok(new SingleResponseModel<int>
                {
                    Success = true,
                    Message = newUserId == null
                         ? "User created successfully"
                         : "User updated successfully",
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

        [HttpGet("vendors")]
        [Authorize]
        public async Task<IActionResult> GetVendor()
        {
            try
            {
                var data = await _service.GetVendorAsync();
                return Ok(new ListResponseModel<VendorResponseDto>
                {
                    Success = true,
                    Message = "Vendor list loaded successfully",
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
