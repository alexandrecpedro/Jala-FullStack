using DDDWebAPI.Application.DTO.DTO;
using DDDWebAPI.Domain.Models;
using DDDWebAPI.Infrastructure.CrossCutting.Adapter.Interfaces;

namespace DDDAPIExample.DDDWebAPI.Infrastructure.CrossCutting.Adapter.Map;

public class MapperCliente : IMapperCliente
{
    #region methods
    
    public Cliente MapperToEntity(ClienteDTO clienteDTO)
    {
        Cliente cliente = new Cliente
        {
            Id = clienteDTO.Id,
            Nome = clienteDTO.Nome,
            Sobrenome = clienteDTO.Sobrenome,
            Email = clienteDTO.Email
        };

        return cliente;
    }

    public IEnumerable<ClienteDTO> MapperListClientes(IEnumerable<Cliente> clientes)
    {
        return clientes.Select(cliente => MapperToDTO(cliente)).ToList();
    }

    public ClienteDTO MapperToDTO(Cliente cliente)
    {
        ClienteDTO clienteDTO = new ClienteDTO
        {
            Id = cliente.Id,
            Nome = cliente.Nome,
            Sobrenome = cliente.Sobrenome,
            Email = cliente.Email
        };

        return clienteDTO;
    }
    
    #endregion
}