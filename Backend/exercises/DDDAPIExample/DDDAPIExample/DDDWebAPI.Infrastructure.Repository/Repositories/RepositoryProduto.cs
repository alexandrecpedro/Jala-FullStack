using DDDWebAPI.Domain.Core.Interfaces.Repositories;
using DDDWebAPI.Domain.Models;
using DDDWebAPI.Infrastructure.Data;

namespace DDDWebAPI.Infrastructure.Repository.Repositories;

public class RepositoryProduto : RepositoryBase<Produto>, IRepositoryProduto
{
    public RepositoryProduto(SqlContext Context) : base(Context)
    {
    }
}