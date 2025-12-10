using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnboardPro.Interfaces.Services;
using OnboardPro.Models;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace OnboardPro.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserMasterController : ControllerBase
    {
        private readonly IUserMasterService _service;

        public UserMasterController(IUserMasterService service)
        {
            _service = service;
        }

        [HttpGet("active-roles")]
        [Authorize]
        public async Task<IActionResult> GetActiveRoles()
        {
            try
            {           
                var data = await _service.GetActiveRolesAsync();
                return Ok(new ListResponseModel<RoleDto>
                {
                    Success = true,
                    Message = "Role list loaded successfully",
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
        public async Task<IActionResult> SaveUser([FromBody] UserDto user)
        {
            try
            {
                var newUserId = await _service.SaveUserAsync(user);
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

        [HttpGet("users")]
        [Authorize]
        public async Task<IActionResult> GetUsers()
        {
            try
            {
                var data = await _service.GetUsersAsync();
                return Ok(new ListResponseModel<UserResponseDto>
                {
                    Success = true,
                    Message = "Users list loaded successfully",
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
