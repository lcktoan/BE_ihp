using System.ComponentModel.DataAnnotations;

public class ProjectRegisterRequest
{
    public required string project_name { get; set; }

    public string? project_description { get; set; }

    public required string project_status { get; set; }

    [Required]
    public required string project_leader { get; set; }
      
    public string[]? project_members { get; set; }

    public string[]? project_skills_required { get; set; }

    public DateOnly StartDate { get; set; }

    public DateOnly EndDate { get; set; }
}