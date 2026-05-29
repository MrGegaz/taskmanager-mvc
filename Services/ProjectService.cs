using taskmanager_mvc.Data;
using taskmanager_mvc.Models;

namespace taskmanager_mvc.Services;

public class ProjectService : IProjectService
{
    private readonly AppDbContext _context;

    public ProjectService(AppDbContext context)
    {
        _context = context;
    }
    
    public async Task<IEnumerable<Project>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public async Task<Project?> GetByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<Project?> CreateAsync(Project project)
    {
        throw new NotImplementedException();
    }

    public async Task<Project?> UpdateAsync(Project project)
    {
        throw new NotImplementedException();
    }

    public async Task<Project> DeleteAsync(int id)
    {
        throw new NotImplementedException();
    }
}