namespace MyApi.src.Entities;

using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

public class User
{
    public int Id { get; set; }

    [Required]
    [StringLength(50)]
    public required string Username { get; set; }

    [Required]
    [JsonIgnore]
    [StringLength(50)]
    public required string Password { get; set; }

    [Required]
    public required string Role { get; set; }

    [Required]
    public required string Email { get; set; }

    [DataType(DataType.Date)]
    [Display(Name = "Registration Date")]
    public DateOnly CreatedAt { get; set; }
}
