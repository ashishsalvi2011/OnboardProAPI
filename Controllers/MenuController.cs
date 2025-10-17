using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnboardPro.Interfaces.Services;

namespace OnboardPro.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MenuController : ControllerBase
    {
        private readonly IMenuService _menuService;

        public MenuController(IMenuService menuService)
        {
            _menuService = menuService;
        }

        [HttpGet("GetMenusByRole/{roleId}")]
        [Authorize]
        public async Task<IActionResult> GetMenusByRole(int roleId)
        {
            var menus = await _menuService.GetMenusByRoleAsync(roleId);
            return Ok(menus);
        }
    }
}
