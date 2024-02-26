using System.ComponentModel.DataAnnotations;

namespace TodoAPI.Models;

public class TodoItem
{
    [Required]
    public Guid Id { get; set; }
    
    [Required]
    public string? Name { get; set; }
    
    // [Required]
    // public string Notes { get; set; }
    
    public bool IsComplete { get; set; }
    
    public string? Secret { get; set; }
}