using ToDoList.Models;
using ToDoList.Repositories.Interfaces;
using ToDoList.UseCases.Interfaces;

namespace ToDoList.UseCases;

public class DeleteUseCase(IToDoRepository toDoRepository): IDeleteUseCase<ToDoItem>
{
    public async Task<bool> Execute(Guid id)
    {
        var deletedToDo = await toDoRepository.Delete(id);
        return deletedToDo;
    }
}