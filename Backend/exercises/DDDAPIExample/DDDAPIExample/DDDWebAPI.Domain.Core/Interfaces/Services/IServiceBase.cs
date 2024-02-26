namespace DDDWebAPI.Domain.Core.Interfaces.Services;

public interface IServiceBase<TEntity> where TEntity : class
{
    void Add(TEntity obj);

    TEntity GetById(Guid id);

    IEnumerable<TEntity> GetAll();

    void Update(TEntity obj);

    void Remove(TEntity obj);

    void Dispose();
}
