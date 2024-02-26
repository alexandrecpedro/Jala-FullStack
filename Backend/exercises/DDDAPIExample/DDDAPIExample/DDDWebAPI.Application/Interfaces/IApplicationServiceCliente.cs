using DDDWebAPI.Application.DTO.DTO;

namespace DDDWebAPI.Application.Interfaces;

public interface IApplicationServiceCliente
{
    void Add(ClienteDTO obj);
    
    void Dispose();

    IEnumerable<ClienteDTO> GetAll();
    
    ClienteDTO GetById(Guid id);

    void Remove(ClienteDTO obj);
    
    void Update(ClienteDTO obj);


}
