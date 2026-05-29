using Microsoft.EntityFrameworkCore;
using taskmanager_mvc.Models;

namespace taskmanager_mvc.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<Project> Projects { get; set; }
    public DbSet<TaskItem> Tasks { get; set; }
}