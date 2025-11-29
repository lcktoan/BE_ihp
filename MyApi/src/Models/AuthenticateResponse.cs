using System.Net.Mail;
using MyApi.src.Entities;

public class AuthenticateResponse
{
    public int Id { get; set; }
    public string Username { get; set; }
    public string Password { get; set; }
    public string Role { get; set; }
    public string Email { get; set; }
    public string Token { get; set; }

    public DateOnly CreatedAt { get; set; }


    public AuthenticateResponse(User user, string token)
    {
        Id = user.Id;
        Username = user.Username;
        Password = user.Password;
        Role = user.Role ?? "";
        Email = user.Email ?? "";
        CreatedAt = user.CreatedAt;
        Token = token;
    }
}