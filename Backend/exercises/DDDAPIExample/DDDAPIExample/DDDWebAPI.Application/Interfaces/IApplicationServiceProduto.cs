using DDDWebAPI.Application.DTO.DTO;

namespace DDDWebAPI.Application.Interfaces;

public interface IApplicationServiceProduto
{
    void Add(ProdutoDTO obj);

    void Dispose();
    
    IEnumerable<ProdutoDTO> GetAll();
    
    ProdutoDTO GetById(Guid id);

    void Remove(ProdutoDTO obj);
    
    void Update(ProdutoDTO obj);
}