namespace DDDWebAPI.Domain.Core.Interfaces.Repositories;

public interface IRepositoryBase<TEntity> where TEntity : class
{
    void Add(TEntity obj);

    TEntity GetById(Guid id);

    IEnumerable<TEntity> GetAll();

    void Update(TEntity obj);

    void Remove(TEntity obj);

    void Dispose();
}
