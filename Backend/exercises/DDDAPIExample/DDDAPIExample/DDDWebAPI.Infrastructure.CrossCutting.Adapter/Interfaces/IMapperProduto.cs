using DDDWebAPI.Application.DTO.DTO;
using DDDWebAPI.Domain.Models;

namespace DDDWebAPI.Infrastructure.CrossCutting.Adapter.Interfaces;

public interface IMapperProduto
{
    #region Interfaces Mappers
    Produto MapperToEntity(ProdutoDTO produtoDTO);

    IEnumerable<ProdutoDTO> MapperListProdutos(IEnumerable<Produto> produtos);

    ProdutoDTO MapperToDTO(Produto produto);

    #endregion
}
