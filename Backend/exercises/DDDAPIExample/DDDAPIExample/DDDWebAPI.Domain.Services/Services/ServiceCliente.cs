using DDDWebAPI.Domain.Core.Interfaces.Repositories;
using DDDWebAPI.Domain.Core.Interfaces.Services;
using DDDWebAPI.Domain.Models;

namespace DDDWebAPI.Domain.Services.Services;

public class ServiceCliente : ServiceBase<Cliente>, IServiceCliente
{
    public ServiceCliente(IRepositoryCliente RepositoryCliente) : base(RepositoryCliente)
    {
    }
}