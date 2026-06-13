using taskmanager_mvc.Models;

namespace taskmanager_mvc.Services;

public interface ITaskService
{
    Task<IEnumerable<TaskItem>> GetAllAsync(string userId);
    Task<TaskItem?> GetByIdAsync(int id);
    Task<IEnumerable<TaskItem>> GetPendingAsync(string userId);
    Task<IEnumerable<TaskItem>> SearchByTitleAsync(string query, string userId);
    Task AddAsync(TaskItem task);
    Task UpdateAsync(TaskItem task);
    Task DeleteAsync(int id);
}