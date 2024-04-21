using Microsoft.EntityFrameworkCore;
using ToDoList.Models;

namespace ToDoList.Database;

public class TodoContext : DbContext
{
    public TodoContext(DbContextOptions<TodoContext> options) : base(options)
    {
    }
    public DbSet<ToDoItem> ToDoItems { get; set; }
}