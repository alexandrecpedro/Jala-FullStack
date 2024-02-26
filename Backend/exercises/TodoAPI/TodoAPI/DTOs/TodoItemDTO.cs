using System.ComponentModel.DataAnnotations;

namespace TodoAPI.DTOs;

public class TodoItemDTO
{
    [Required]
    public Guid Id { get; set; }
    
    [Required]
    public string? Name { get; set; }
    
    public bool IsComplete { get; set; }
}