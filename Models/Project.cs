using System.ComponentModel.DataAnnotations;

namespace taskmanager_mvc.Models;

public class Project
{
    public int Id { get; set; }

    [Required] [MaxLength(100)] public string Name { get; set; } = String.Empty;
    
    public string? Description { get; set; }
    
    [Required]
    public DateTime StartDate { get; set; }
    
    public DateTime EndDate { get; set; }
    
    [Required]
    public Boolean IsActive { get; set; }

    public ICollection<TaskItem> Tasks { get; set; } = new List<TaskItem>();

}