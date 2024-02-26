using DDDWebAPI.Domain.Core.Interfaces.Repositories;
using DDDWebAPI.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace DDDWebAPI.Infrastructure.Repository.Repositories;

public abstract class RepositoryBase<TEntity> : IDisposable, IRepositoryBase<TEntity> where TEntity : class
{
    private readonly SqlContext _context;

    public RepositoryBase(SqlContext Context)
    {
        _context = Context;
    }

    public virtual void Add(TEntity obj)
    {
        try
        {
            _context.Set<TEntity>().Add(obj);
            _context.SaveChanges();
        }
        catch (BadHttpRequestException e)
        {
            throw new BadHttpRequestException(e.Message);
        }
    }
    
    public virtual void Dispose()
    {
        _context.Dispose();
    }
    
    public virtual IEnumerable<TEntity> GetAll()
    {
        return _context.Set<TEntity>().ToList();
    }

    public virtual TEntity GetById(Guid id)
    {
        try
        {
            var entityDB = _context.Set<TEntity>().Find(id);

            if (entityDB == null)
            {
                throw new FileNotFoundException($"{typeof(TEntity).Name} com o ID {id} não foi encontrado(a).");
            }

            return entityDB;
        }
        catch (BadHttpRequestException e)
        {
            throw new BadHttpRequestException(e.Message);
        }
    }
    
    public virtual void Remove(TEntity obj)
    {
        try
        {
            _context.Set<TEntity>().Remove(obj);
            _context.SaveChanges();
        }
        catch (BadHttpRequestException e)
        {
            throw new BadHttpRequestException(e.Message);
        }
    }

    public virtual void Update(TEntity obj)
    {
        try
        {
            _context.Entry(obj).State = EntityState.Modified;
            _context.SaveChanges();
        }
        catch (BadHttpRequestException e)
        {
            throw new BadHttpRequestException(e.Message);
        }
    }
}
