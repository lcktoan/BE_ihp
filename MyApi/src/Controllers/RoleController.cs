using Microsoft.AspNetCore.Mvc;

namespace MyApi.Controllers
{
    [ApiController]
    [Route("api/roles")]
    public class RoleController : ControllerBase
    {
        private readonly RoleService _roleService;

        public RoleController(RoleService roleService)
        {
            _roleService = roleService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var roles = _roleService.GetAllRoles();
            return Ok(roles);
        }
    }
}