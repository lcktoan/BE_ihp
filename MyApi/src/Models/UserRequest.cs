using System.ComponentModel.DataAnnotations;

public class UserRequest
{
    public int Id { get; set; }

    [Required]
    public required string Username { get; set; }

    [Required]
    public required string Password { get; set; }

    public string? Role { get; set; }

    public string? Email { get; set; }

    public DateOnly CreatedAt { get; set; }
}