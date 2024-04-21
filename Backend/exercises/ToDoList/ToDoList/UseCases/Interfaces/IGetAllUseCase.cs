namespace ToDoList.UseCases.Interfaces;

public interface IGetAllUseCase<T> where T : class
{
    Task<IEnumerable<T>> Execute();
}