using ToDoList.Models;
using ToDoList.Repositories.Interfaces;
using ToDoList.UseCases.Interfaces;

namespace ToDoList.UseCases;

public class CreateUseCase(IToDoRepository toDoRepository): ICreateUseCase<ToDoItem>
{
    public async Task<ToDoItem> Execute(ToDoItem toDo)
    {
        var createdTodo = await toDoRepository.Create(toDo);
        return createdTodo;
    }
}