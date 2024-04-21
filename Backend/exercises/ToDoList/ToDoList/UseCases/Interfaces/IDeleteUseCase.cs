namespace ToDoList.UseCases.Interfaces;

public interface IDeleteUseCase<T> where T : class
{
    Task<bool> Execute(Guid id);
}