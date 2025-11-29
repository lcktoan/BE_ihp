namespace MyApi.src.Entities;

using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

public class Project
{
    [Key]
    public int project_id { get; set; }

    [Required]
    [StringLength(50)]
    public required string project_name { get; set; }

    public string? project_description { get; set; }

    public required string project_status { get; set; }

    [Required]
    [StringLength(50)]
    public required string project_leader { get; set; }

    public string[]? project_members { get; set; }

    public string[]? project_skills_required { get; set; }

    [DataType(DataType.Date)]
    [Display(Name = "Start Date")]
    public DateOnly StartDate { get; set; }

    [DataType(DataType.Date)]
    [Display(Name = "End Date")]
    public DateOnly EndDate { get; set; }

}