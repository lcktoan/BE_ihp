using MyApi.Models;
using MyApi.src.Entities;

public class ProjectService
{
    private readonly MyDbContext _dbContext;

    public ProjectService(MyDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public void CreateProject(ProjectRegisterRequest model)
    {
        var project = new Project
        {
            project_name = model.project_name,
            project_description = model.project_description,
            project_status = model.project_status,
            project_leader = model.project_leader,
            project_members = model.project_members,
            project_skills_required = model.project_skills_required,
            StartDate = model.StartDate,
            EndDate = model.EndDate
        };

        _dbContext.Projects.Add(project);
        _dbContext.SaveChanges();
    }
}