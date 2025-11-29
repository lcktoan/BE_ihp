// using Microsoft.AspNetCore.Mvc;
// using Microsoft.EntityFrameworkCore;
// using MyApi.Models;
// using MyApi.src.Entities;

// namespace MyApi.Controllers
// {
//     [ApiController]
//     [Route("api/users")]
//     public class UserController : ControllerBase
//     {
//         private readonly MyDbContext _dbContext;
//         private IUserService _userService;

//         public UserController(MyDbContext dbContext, IUserService userService)
//         {
//             _dbContext = dbContext;
//             _userService = userService;
//         }


//         [HttpPost("authenticate")]
//         public IActionResult Authenticate(AuthenticateRequest model)
//         {
//             var response = _userService.Authenticate(model);

//             if (response == null)
//                 return BadRequest(new { message = "Username or password is incorrect" });

//             return Ok(response);
//         }

//         [Authorize]
//         [HttpGet]
//         public IActionResult GetAll()
//         {
//             var users = _userService.GetAll();
//             return Ok(users);
//         }
    
//         [HttpGet("{id}")]
//         public async Task<IActionResult> GetUserById(int id)
//         {
//             var user = await _dbContext.Users.FindAsync(id);
//             if (user == null)
//             {
//                 return NotFound();
//             }
//             return Ok(user);
//         }

//         // [HttpGet]
//         // public async Task<IActionResult> GetAllUsers()
//         // {
//         //     var users = await _dbContext.Users.ToListAsync();
//         //     return Ok(users);
//         // }
        
//         [HttpPost]
//         public async Task<IActionResult> CreateUser([FromBody] UserRequest userRequest)
//         {
//             if (!ModelState.IsValid)
//             {
//                 return BadRequest(ModelState);
//             }

//             var user = new User
//             {
//                 Username = userRequest.Username,
//                 Password = userRequest.Password,
//                 Role = userRequest.Role,
//                 Email = userRequest.Email,
//                 CreatedAt = userRequest.CreatedAt
//             };

//             _dbContext.Users.Add(user);
//             await _dbContext.SaveChangesAsync();

//             return CreatedAtAction(nameof(GetUserById), new { id = user.Id }, user);
//         }
//     }
// }