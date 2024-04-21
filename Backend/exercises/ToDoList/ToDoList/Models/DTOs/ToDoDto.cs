using ToDoList.Models.Enums;

namespace ToDoList.Models.DTOs;

public class ToDoDto
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public DateTime DueTime { get; set; }
    public Priority Priority { get; set; }
}