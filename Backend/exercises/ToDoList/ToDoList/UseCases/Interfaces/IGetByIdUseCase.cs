namespace ToDoList.UseCases.Interfaces;

public interface IGetByIdUseCase<T> where T : class
{
    Task<T?> Execute(Guid id);
}