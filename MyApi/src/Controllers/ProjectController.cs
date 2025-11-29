using Microsoft.AspNetCore.Mvc;
using MyApi.Models;
using MyApi.src.Entities;
using MyApi.src.Services;

[ApiController]
[Route("api/projects")]
public class ProjectController : ControllerBase
{
    private readonly ProjectService _projectService;

    public ProjectController(ProjectService projectService)
    {
        _projectService = projectService;
    }

    [HttpPost("register")]
    public IActionResult Register([FromBody] ProjectRegisterRequest model)
    {
        try
        {
            _projectService.CreateProject(model);
            return Ok(new { message = "Project registered successfully." });
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { message = "An error occurred while registering the project.", error = ex.Message });
        }
    }
}