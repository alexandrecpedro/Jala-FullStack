using ToDoList.Models.Enums;

namespace ToDoList.Models.DTOs;

public class CreateToDoDto
{
    public string Title { get; set; }
    public string Description { get; set; }
    public DateTime DueTime { get; set; }
    public Priority Priority { get; set; }
    public Status Status { get; set; }
}