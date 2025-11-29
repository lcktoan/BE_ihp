using MyApi.src.Entities;

public class RoleResponse
{
    public int Id { get; set; }
    public string Role_Name { get; set; }
    public string Role_Desciption { get; set; }

    public RoleResponse(int id, string role_Name, string role_Desciption)
    {
        Id = id;
        Role_Name = role_Name;
        Role_Desciption = role_Desciption;
    }
}