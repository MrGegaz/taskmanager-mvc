using taskmanager_mvc.Data;
using taskmanager_mvc.Models;

namespace taskmanager_mvc.Services;

public class TaskService : ITaskService
{
    protected readonly AppDbContext _context;

    public TaskService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<TaskItem>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public async Task<TaskItem?> GetByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<TaskItem>> GetPendingAync()
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<TaskItem>> SearchByTitleAsync(string query)
    {
        throw new NotImplementedException();
    }

    public async Task AddAsync(TaskItem task)
    {
        throw new NotImplementedException();
    }

    public async Task UpdateAsync(TaskItem task)
    {
        throw new NotImplementedException();
    }

    public async Task DeleteAsync(int id)
    {
        throw new NotImplementedException();
    }
}