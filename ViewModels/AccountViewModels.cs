using System.ComponentModel.DataAnnotations;

namespace taskmanager_mvc.ViewModels;

public class AccountViewModels
{
    public class LoginViewModel
    {
        [Required] [EmailAddress] public string Email { get; set; } = string.Empty;
        
        [Required] [DataType(DataType.Password)] public string Password { get; set; } = string.Empty;
    }
    
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "Korisničko ime je obavezno!")]
        [StringLength(30, ErrorMessage = "Korisničko ime ne može biti duže od 30 znakova!")]
        public string Username { get; set; } = string.Empty;
        
        [Required(ErrorMessage = "Email je obavezan!")]
        [EmailAddress] public string Email { get; set; } = string.Empty;
        
        [Required(ErrorMessage = "Lozinka je obavezna!")]
        [DataType(DataType.Password)] 
        [StringLength(100, MinimumLength = 8)]
        public string Password { get; set; } = string.Empty;
        
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Lozinke se ne podudaraju!")]
        public string ConfirmPassword { get; set; } = string.Empty;
    }
    
    public class ProfileViewModel
    {
        [Required] public string Username { get; set; } = string.Empty;
        [Required] public string Email { get; set; } = string.Empty;
    }
}