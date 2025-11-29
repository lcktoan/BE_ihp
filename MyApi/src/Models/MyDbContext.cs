using Microsoft.EntityFrameworkCore;
using MyApi.src.Entities;

namespace MyApi.Models
{
    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }

        public DbSet<Role> Roles { get; set; }

        public DbSet<Project> Projects { get; set; }
    }
}