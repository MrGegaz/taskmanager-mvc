using taskmanager_mvc.Models;

namespace taskmanager_mvc.Services;

public interface IProjectService
{
    Task<IEnumerable<Project>> GetAllAsync();
    Task<Project?> GetByIdAsync(int id);
    Task<Project?> CreateAsync(Project project);
    Task<Project?> UpdateAsync(Project project);
    Task<Project> DeleteAsync(int id);
}