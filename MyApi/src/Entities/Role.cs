namespace MyApi.src.Entities;

using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

public class Role
{
    public int Id { get; set; }

    [Required]
    [StringLength(50)]
    public required string Role_Name { get; set; }

    [Required]
    [StringLength(50)]
    public required string Role_Desciption { get; set; }

}
