using MyApi.Models;

public class RoleService
{
    private readonly MyDbContext _dbContext;

    public RoleService(MyDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public List<RoleResponse> GetAllRoles()
    {
        return [.. _dbContext.Roles.Select(r => new RoleResponse(r.Id, r.Role_Name, r.Role_Desciption))];
    }
}