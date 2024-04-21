using ToDoList.Models;
using ToDoList.Repositories.Interfaces;
using ToDoList.UseCases.Interfaces;

namespace ToDoList.UseCases;

public class UpdateUseCase(IToDoRepository toDoRepository): IUpdateUseCase<ToDoItem>
{
    public async Task<ToDoItem> Execute(Guid id, ToDoItem toDo)
    {
        var updatedToDo = await toDoRepository.Update(id, toDo);
        return updatedToDo;
    }
}