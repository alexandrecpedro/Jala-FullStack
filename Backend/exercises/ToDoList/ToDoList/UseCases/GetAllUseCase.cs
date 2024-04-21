using ToDoList.Models;
using ToDoList.Repositories.Interfaces;
using ToDoList.UseCases.Interfaces;

namespace ToDoList.UseCases;

public class GetAllUseCase(IToDoRepository toDoRepository): IGetAllUseCase<ToDoItem>
{
    public async Task<IEnumerable<ToDoItem>> Execute()
    {
        var getToDos = await toDoRepository.GetAll();
        return getToDos;
    }
}