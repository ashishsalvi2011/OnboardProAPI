using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnboardPro.Interfaces.Services;
using OnboardPro.Models;

namespace OnboardPro.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MasterController : ControllerBase
    {
        private readonly IMasterService _masterService;
        public MasterController(IMasterService masterService)
        {
            _masterService = masterService;
        }

        [HttpGet("get")]
        public async Task<IActionResult> GetMasterData([FromQuery] string? masterType)
        {
            try
            { 
                var data = await _masterService.GetMasterDataAsync(masterType);

                return Ok(new ListResponseModel<MasterDto>
                {
                    Success = true,
                    Message = "genders list loaded successfully",
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
