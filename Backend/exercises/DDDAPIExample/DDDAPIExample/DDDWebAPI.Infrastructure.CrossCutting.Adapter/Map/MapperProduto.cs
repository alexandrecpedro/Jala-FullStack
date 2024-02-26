using DDDWebAPI.Application.DTO.DTO;
using DDDWebAPI.Domain.Models;
using DDDWebAPI.Infrastructure.CrossCutting.Adapter.Interfaces;

namespace DDDAPIExample.DDDWebAPI.Infrastructure.CrossCutting.Adapter.Map;

public class MapperProduto : IMapperProduto
{
    #region methods
    
    public Produto MapperToEntity(ProdutoDTO produtoDTO)
    {
        Produto produto = new Produto
        {
            Id = produtoDTO.Id,
            Nome = produtoDTO.Nome,
            Valor = produtoDTO.Valor
        };
        
        return produto;
    }

    public IEnumerable<ProdutoDTO> MapperListProdutos(IEnumerable<Produto> produtos)
    {
        return produtos.Select(produto => MapperToDTO(produto)).ToList();
    }

    public ProdutoDTO MapperToDTO(Produto produto)
    {
        ProdutoDTO produtoDTO = new ProdutoDTO
        {
            Id = produto.Id,
            Nome = produto.Nome,
            Valor = produto.Valor
        };
        
        return produtoDTO;
    }
    
    #endregion
}