using DDDWebAPI.Domain.Core.Interfaces.Repositories;
using DDDWebAPI.Domain.Models;
using DDDWebAPI.Infrastructure.Data;

namespace DDDWebAPI.Infrastructure.Repository.Repositories;

public class RepositoryCliente : RepositoryBase<Cliente>, IRepositoryCliente
{
    public RepositoryCliente(SqlContext Context) : base(Context)
    {
    }
}