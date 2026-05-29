using taskmanager_mvc.Models;

namespace taskmanager_mvc.Services;

public interface ITaskService
{
    Task<IEnumerable<TaskItem>> GetAllAsync();
    Task<TaskItem?> GetByIdAsync(int id);
    Task<IEnumerable<TaskItem>> GetPendingAsync();
    Task<IEnumerable<TaskItem>> SearchByTitleAsync(string query);
    Task AddAsync(TaskItem task);
    Task UpdateAsync(TaskItem task);
    Task DeleteAsync(int id);
}