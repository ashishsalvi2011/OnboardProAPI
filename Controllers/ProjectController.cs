using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using OnboardPro.Interfaces.Services;
using OnboardPro.Models;

namespace OnboardPro.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectController : ControllerBase
    {
        private readonly IProjectService _service;

        public ProjectController(IProjectService service)
        {
            _service = service;
        }

        [HttpPost("save")]
        [Authorize]
        public async Task<IActionResult> SaveProject([FromBody] ProjectDto model)
        {
            try
            {
                var projectId = await _service.InsertOrUpdateProjectAsync(model);

                return Ok(new SingleResponseModel<int>
                {
                    Success = true,
                    Message = model.ProjectId == null
                            ? "Project created successfully"
                            : "Project updated successfully",
                    Data = projectId
                });
            }
            catch (SqlException ex)
            {
                return BadRequest(new SingleResponseModel<string>
                {
                    Success = false,
                    Message = ex.Message,
                    Data = null
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new SingleResponseModel<string>
                {
                    Success = false,
                    Message = "Internal Server Error: " + ex.Message,
                    Data = null
                });
            }
        }

        [HttpGet("list")]
        [Authorize]
        public async Task<IActionResult> GetProjects()
        {
            try
            {
                var data = await _service.GetProjectsAsync();

                return Ok(new ListResponseModel<ProjectListDto>
                {
                    Success = true,
                    Message = "Project list loaded successfully",
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
