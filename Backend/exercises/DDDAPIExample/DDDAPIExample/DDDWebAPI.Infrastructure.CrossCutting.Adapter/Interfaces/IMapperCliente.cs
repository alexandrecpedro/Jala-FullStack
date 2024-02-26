using DDDWebAPI.Application.DTO.DTO;
using DDDWebAPI.Domain.Models;

namespace DDDWebAPI.Infrastructure.CrossCutting.Adapter.Interfaces;

public interface IMapperCliente
{
    #region Mappers

    Cliente MapperToEntity(ClienteDTO clienteDTO);

    IEnumerable<ClienteDTO> MapperListClientes(IEnumerable<Cliente> clientes);

    ClienteDTO MapperToDTO(Cliente cliente);

    #endregion
}