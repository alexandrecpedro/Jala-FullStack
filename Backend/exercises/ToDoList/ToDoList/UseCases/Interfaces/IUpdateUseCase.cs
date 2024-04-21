namespace ToDoList.UseCases.Interfaces;

public interface IUpdateUseCase<T> where T : class
{
    Task<T> Execute(Guid id, T t);
}