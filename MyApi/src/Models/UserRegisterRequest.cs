using System.ComponentModel.DataAnnotations;

public class UserRegisterRequest
{
    public required string Username { get; set; }

    [Required]
    public required string Email { get; set; }

    [Required]
    public required string Password { get; set; }

     [Required]
    public required string Role { get; set; }
}