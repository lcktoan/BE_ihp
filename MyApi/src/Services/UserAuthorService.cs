namespace MyApi.src.Services;

using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

public class UserAuthorService
{
    private readonly IConfiguration _configuration;

    public UserAuthorService(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public string GenerateToken(string username, string roles, string email)
    {
        var claims = new List<Claim>
        {
            new Claim(ClaimTypes.Name, username),
            new Claim(ClaimTypes.Role, roles),
            new Claim(ClaimTypes.Email, email)
        };

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JwtSettings:Secret"]));
        var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
        var expirationTime = DateTime.Now.AddMinutes(Convert.ToDouble(_configuration["JwtSettings:ExpirationMinutes"]));

        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(claims),
            Expires = expirationTime,
            Issuer = _configuration["JwtSettings:Issuer"],
            Audience = _configuration["JwtSettings:Audience"],
            SigningCredentials = credentials
        };

        var tokenHandler = new JwtSecurityTokenHandler();
        var token = tokenHandler.CreateToken(tokenDescriptor);

        return tokenHandler.WriteToken(token);
    }
}