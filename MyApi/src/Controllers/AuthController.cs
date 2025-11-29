using Microsoft.AspNetCore.Mvc;
using MyApi.Models;
using MyApi.src.Entities;
using MyApi.src.Services;

[ApiController]
[Route("api/auth")]
public class AuthController : ControllerBase
{
    private readonly UserAuthorService _UserAuthorService;
    private readonly MyDbContext _dbContext;

    public AuthController(UserAuthorService UserAuthorService, MyDbContext dbContext)
    {
        _UserAuthorService = UserAuthorService;
        _dbContext = dbContext;
    }

    [HttpPost("login")]
    public IActionResult Login([FromBody] AuthenticateRequest model)
    {
        // Get logged in user from database
        var user = _dbContext.Users.FirstOrDefault(u => u.Username == model.Username && u.Password == model.Password);

        if (user == null)
        {
            return Unauthorized(new { message = "Invalid username or password" });
        }

        // 2. Generate the token
        var token = _UserAuthorService.GenerateToken(user.Username, user.Role, user.Email);

        // 3. Return the token
        return Ok(new { Token = token });
    }

    [HttpPost("register")]
    public IActionResult Register([FromBody] UserRegisterRequest model)
    {
        // Get logged in user from database
        var user = _dbContext.Users.FirstOrDefault(u => u.Email == model.Email);

        if (user != null)
        {
            return Unauthorized(new { message = "Invalid username or password" });
        }

        // Create new user
        user = new User
        {
            Username = model.Username,
            Email = model.Email,
            Password = model.Password,
            Role = model.Role,
            CreatedAt = DateOnly.FromDateTime(DateTime.Now)
        };

        _dbContext.Users.Add(user);
        _dbContext.SaveChanges();

        // 2. Generate the token
        var token = _UserAuthorService.GenerateToken(user.Username, user.Role, user.Email);

        // 3. Return the token
        return Ok(new { Token = token });
    }
}