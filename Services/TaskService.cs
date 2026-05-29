using Microsoft.EntityFrameworkCore;
using taskmanager_mvc.Data;
using taskmanager_mvc.Models;

namespace taskmanager_mvc.Services;

public class TaskService : ITaskService
{
    private readonly AppDbContext _context;

    public TaskService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<TaskItem>> GetAllAsync()
    {
        return await _context.Tasks
            .Include(t => t.Project)
            .ToListAsync();
    }

    public async Task<TaskItem?> GetByIdAsync(int id)
    {
        return await _context.Tasks
            .Include(t => t.Project)
            .FirstOrDefaultAsync(t => t.Id == id);
    }

    public async Task<IEnumerable<TaskItem>> GetPendingAsync()
    {
        return await _context.Tasks
            .Include(t => t.Project)
            .Where(t => !t.IsCompleted)
            .ToListAsync();
    }

    public async Task<IEnumerable<TaskItem>> SearchByTitleAsync(string query)
    {
        return await _context.Tasks
            .Include(t => t.Project)
            .Where(t => t.Title.Contains(query))
            .ToListAsync();
    }

    public async Task AddAsync(TaskItem task)
    {
        _context.Tasks.Add(task);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(TaskItem task)
    {
        _context.Tasks.Update(task);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var task = await _context.Tasks.FindAsync(id);
        if (task == null) return;
        
        _context.Tasks.Remove(task);
        await _context.SaveChangesAsync();
    }
}