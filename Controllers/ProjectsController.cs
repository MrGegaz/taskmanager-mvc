using Microsoft.AspNetCore.Mvc;
using taskmanager_mvc.Models;
using taskmanager_mvc.Services;

namespace taskmanager_mvc.Controllers;

public class ProjectsController : Controller
{
    private readonly IProjectService _projectService;

    public ProjectsController(IProjectService projectService)
    {
        _projectService = projectService;
    }

    // GET: Projects
    public async Task<IActionResult> Index()
    {
        var projects = await _projectService.GetAllAsync();
        return View(projects);
    }

    // GET: Projects/Details/x
    public async Task<IActionResult> Details(int id)
    {
        var project = await _projectService.GetByIdAsync(id);
        if (project == null) return NotFound();
        return View(project);
    }
    
    // GET: Projects/Active/x
    public async Task<IActionResult> Active(bool isActive)
    {
        var project = await _projectService.GetActiveAsync(isActive);
        if (project == null) return NotFound();
        return View(project);
    }

    // GET: Projects/Create
    public IActionResult Create()
    {
        return View();
    }

    // POST: Projects/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(Project project)
    {
        if (!ModelState.IsValid) return View(project);
        await _projectService.CreateAsync(project);
        return RedirectToAction(nameof(Index));
    }

    // GET: Projects/Edit/x
    public async Task<IActionResult> Edit(int id)
    {
        var project = await _projectService.GetByIdAsync(id);
        if (project == null) return NotFound();
        return View(project);
    }

    // POST: Projects/Edit/x
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(Project project)
    {
        if (!ModelState.IsValid) return View(project);
        var result = await _projectService.UpdateAsync(project);
        if (result == null) return NotFound();
        return RedirectToAction(nameof(Index));
    }

    // GET: Projects/Delete/x
    public async Task<IActionResult> Delete(int id)
    {
        var project = await _projectService.GetByIdAsync(id);
        if (project == null) return NotFound();
        return View(project);
    }

    // POST: Projects/Delete/x
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        await _projectService.DeleteAsync(id);
        return RedirectToAction(nameof(Index));
    }
}