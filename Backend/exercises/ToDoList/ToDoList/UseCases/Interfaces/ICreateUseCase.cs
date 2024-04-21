namespace ToDoList.UseCases.Interfaces;

public interface ICreateUseCase<T> where T : class
{
    Task<T> Execute(T t);
}