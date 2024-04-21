namespace ToDoList.Repositories.Interfaces;

public interface IBaseRepository<T> where T : class
{
    Task<T> Create(T entity);
    Task<bool> Delete(Guid id);
    Task<T?> Get(Guid id);
    Task<IEnumerable<T>> GetAll();
    Task<T> Update(Guid id, T entity);
}