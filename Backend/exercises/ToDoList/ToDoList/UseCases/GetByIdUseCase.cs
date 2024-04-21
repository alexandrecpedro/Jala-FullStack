using System.Net;
using ToDoList.Exceptions;
using ToDoList.Models;
using ToDoList.Repositories.Interfaces;
using ToDoList.UseCases.Interfaces;

namespace ToDoList.UseCases;

public class GetByIdUseCase(IToDoRepository toDoRepository): IGetByIdUseCase<ToDoItem>
{
    public async Task<ToDoItem?> Execute(Guid id)
    {
        var getToDo = await toDoRepository.Get(id);
        return getToDo;
    }
}