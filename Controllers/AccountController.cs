using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using taskmanager_mvc.Models;
using taskmanager_mvc.ViewModels;

namespace taskmanager_mvc.Controllers;

public class AccountController : Controller
{
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly SignInManager<ApplicationUser> _signInManager;
    
    public AccountController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
    {
        _userManager = userManager;
        _signInManager = signInManager;
    }
    
    // POST: Login
    [HttpPost]
    public async Task<IActionResult> Login(AccountViewModels.LoginViewModel model)
    {
        if (!ModelState.IsValid) return View(model);

        var user = await _userManager.FindByEmailAsync(model.Email);
        if (user == null)
        {
            ModelState.AddModelError(string.Empty, "Neispravan email ili lozinka!");
            return View(model);
        }

        var result = await _signInManager.PasswordSignInAsync(user.UserName!, model.Password, false, false);

        if (result.Succeeded)
            return RedirectToAction("Index", "Home");

        ModelState.AddModelError(string.Empty, "Neispravan email ili lozinka!");
        return View(model);
    }
    
    // GET: Login form
    [HttpGet]
    public IActionResult Login() => View();
    
    //P OST: Register
    [HttpPost]
    public async Task<IActionResult> Register(AccountViewModels.RegisterViewModel model)
    {
        if (!ModelState.IsValid) return View(model);
        
        var user = new ApplicationUser { UserName = model.Username, Email = model.Email };
        
        var result = await _userManager.CreateAsync(user, model.Password);

        if (result.Succeeded)
        {
            await _signInManager.SignInAsync(user, isPersistent: false);
            return RedirectToAction("Index", "Home");
        }
        
        foreach (var error in result.Errors) 
        { 
            ModelState.AddModelError(string.Empty, error.Description);
        }
        
        return View(model);
    }
    
    // GET: Register form
    [HttpGet]
    public IActionResult Register() => View();
    
    // POST: Logout
    [HttpPost]
    public async Task<IActionResult> Logout()
    {
        await _signInManager.SignOutAsync();
        return RedirectToAction("Index", "Home");
    }
    
    // UPDATE: Profile form
    [HttpPost]
    public async Task<IActionResult> Profile(AccountViewModels.ProfileViewModel model)
    {
        if (!ModelState.IsValid) return View(model);
        
        var user = await _userManager.GetUserAsync(User);
        if (user == null) return NotFound();
        
        user.UserName = model.Username;
        user.Email = model.Email;
        
        var result = await _userManager.UpdateAsync(user);
        
        if (result.Succeeded)
        {
            return RedirectToAction("Profile");
        }
        
        foreach (var error in result.Errors) 
        { 
            ModelState.AddModelError(string.Empty, error.Description);
        }
        
        return View("Profile", model);
    }
    
    // GET: Profile
    [HttpGet]
    public async Task<IActionResult> Profile()
    {
        var user = await _userManager.GetUserAsync(User);
        if (user == null) return NotFound();
        
        var model = new AccountViewModels.ProfileViewModel
        {
            Username = user.UserName ?? string.Empty,
            Email = user.Email ?? string.Empty,
        };
        
        return View(model);
    }
}