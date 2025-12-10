using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnboardPro.Interfaces.Services;
using OnboardPro.Models;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace OnboardPro.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SkillMasterController : ControllerBase
    {
        private readonly ISkillMasterService _skillService;

        public SkillMasterController(ISkillMasterService skillService)
        {
            _skillService = skillService;
        }

        [HttpGet("get-all")]
        [Authorize]
        public async Task<IActionResult> GetAllSkillMasterData()
        {
            try
            {
                var data = await _skillService.GetAllSkillMasterDataAsync();
                return Ok(data);
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

        [HttpPost("save-skill")]
        [Authorize]
        public async Task<IActionResult> SaveSkill([FromBody] SkillDto skill)
        {
            try
            {
                var newSkillId = await _skillService.SaveSkillAsync(skill);
                return Ok(new SingleResponseModel<int>
                {
                    Success = true,
                    Message = newSkillId == null
                             ? "Skill created successfully"
                             : "Skill updated successfully",
                    Data = newSkillId
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

        [HttpGet("get-skills")]
        [Authorize]
        public async Task<IActionResult> GetSkills()
        {
            try
            {
                var data = await _skillService.GetSkillsAsync();                 
                return Ok(new ListResponseModel<SkillResponseDto>
                {
                    Success = true,
                    Message = "Skill list loaded successfully",
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
