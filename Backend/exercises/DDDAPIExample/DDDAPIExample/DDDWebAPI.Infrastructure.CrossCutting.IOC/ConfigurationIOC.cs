using Autofac;
using DDDAPIExample.DDDWebAPI.Infrastructure.CrossCutting.Adapter.Map;
using DDDWebAPI.Application.Interfaces;
using DDDWebAPI.Application.Services;
using DDDWebAPI.Domain.Core.Interfaces.Repositories;
using DDDWebAPI.Domain.Core.Interfaces.Services;
using DDDWebAPI.Domain.Services.Services;
using DDDWebAPI.Infrastructure.CrossCutting.Adapter.Interfaces;
using DDDWebAPI.Infrastructure.Repository.Repositories;

namespace DDDWebAPI.Infrastructure.CrossCutting.IOC;

public class ConfigurationIOC
{
    public static void Load(ContainerBuilder builder)
    {
        #region Registra IOC

        #region IOC Application
        builder.RegisterType<ApplicationServiceCliente>().As<IApplicationServiceCliente>();
        builder.RegisterType<ApplicationServiceProduto>().As<IApplicationServiceProduto>();
        #endregion

        #region IOC Services
        builder.RegisterType<ServiceCliente>().As<IServiceCliente>();
        builder.RegisterType<ServiceProduto>().As<IServiceProduto>();
        #endregion

        #region IOC Repositories SQL
        builder.RegisterType<RepositoryCliente>().As<IRepositoryCliente>();
        builder.RegisterType<RepositoryProduto>().As<IRepositoryProduto>();
        #endregion

        #region IOC Mapper
        builder.RegisterType<MapperCliente>().As<IMapperCliente>();
        builder.RegisterType<MapperProduto>().As<IMapperProduto>();
        #endregion

        #endregion
    }
}