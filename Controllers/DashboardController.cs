using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnboardPro.Interfaces.Services;
using OnboardPro.Models;

namespace OnboardPro.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DashboardController : ControllerBase
    {
        private readonly IDashboardService _dashboardService;
        public DashboardController(IDashboardService dashboardService)
        {
            _dashboardService = dashboardService;
        }

        [HttpGet("dashboard-stats")]
        public async Task<IActionResult> GeDashboardStatsDatails()
        {
            try
            { 
                var data = await _dashboardService.GeDashboardStatsDatails();

                return Ok(new ListResponseModel<DashboardStatDto>
                {
                    Success = true,
                    Message = "Dashboard Stats loaded successfully",
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
