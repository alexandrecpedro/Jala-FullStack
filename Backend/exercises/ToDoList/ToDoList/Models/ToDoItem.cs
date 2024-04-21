using System.ComponentModel.DataAnnotations;
using ToDoList.Models.Enums;

namespace ToDoList.Models;

public class ToDoItem
{
    [Key]
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public DateTime DueTime { get; set; }
    public Priority Priority { get; set; } = Priority.Uncategorized;
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
    public DateTime? DeletedAt { get; set; }
}