using DDDWebAPI.Domain.Core.Interfaces.Repositories;
using DDDWebAPI.Domain.Core.Interfaces.Services;
using DDDWebAPI.Domain.Models;

namespace DDDWebAPI.Domain.Services.Services;

public class ServiceProduto : ServiceBase<Produto>, IServiceProduto
{
    public ServiceProduto(IRepositoryProduto RepositoryProduto) : base(RepositoryProduto)
    {
    }
}