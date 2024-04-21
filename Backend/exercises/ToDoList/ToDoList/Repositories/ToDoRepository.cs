using System.Net;
using Microsoft.EntityFrameworkCore;
using ToDoList.Database;
using ToDoList.Exceptions;
using ToDoList.Models;
using ToDoList.Repositories.Interfaces;

namespace ToDoList.Repositories;

public class ToDoRepository(TodoContext context) : IToDoRepository
{
    public async Task<ToDoItem> Create(ToDoItem entity)
    {
        await context.ToDoItems.AddAsync(entity);
        await context.SaveChangesAsync();
        return entity;
    }
    
    public async Task<bool> Delete(Guid id)
    {
        var todoFound = await Get(id);
        if (todoFound is null)
        {
            return false;
        }
        
        todoFound.UpdatedAt = DateTime.UtcNow;
        todoFound.DeletedAt = DateTime.UtcNow;
        
        context.ToDoItems.Update(todoFound);
        await context.SaveChangesAsync();
        
        return true;
    }

    public async Task<ToDoItem?> Get(Guid id)
    {
        var todoFound = await context.ToDoItems.FirstOrDefaultAsync(x => x.Id == id);
        if (todoFound is null) 
            throw new ApiException(HttpStatusCode.NotFound, "ToDo item not found!");
        return todoFound;
    }

    public async Task<IEnumerable<ToDoItem>> GetAll()
    {
        var todoDb = await context.ToDoItems.Where(item => item.DeletedAt == null).ToListAsync();
        return todoDb;
    }

    public async Task<ToDoItem> Update(Guid id, ToDoItem entity)
    {
        var todoFound = await Get(id);
        if (todoFound is null) 
            throw new ApiException(HttpStatusCode.NotFound, "ToDo item not found!");
        
        todoFound.Title = entity.Title;
        todoFound.Description = entity.Description;
        todoFound.DueTime = entity.DueTime;
        todoFound.UpdatedAt = DateTime.UtcNow;

        context.ToDoItems.Update(todoFound);
        await context.SaveChangesAsync();
        
        return todoFound;
    }
}