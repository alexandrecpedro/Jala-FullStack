using DDDWebAPI.Application.DTO.DTO;
using DDDWebAPI.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace WebApiDDD.Presentation.Controllers;

[Route("[controller]")]
[ApiController]
public class ProdutosController : ControllerBase
{
    private readonly IApplicationServiceProduto _applicationServiceProduto;

    public ProdutosController(IApplicationServiceProduto ApplicationServiceProduto)
    {
        _applicationServiceProduto = ApplicationServiceProduto;
    }
    
    // GET api/values
    [HttpGet]
    public ActionResult<IEnumerable<string>> GetAll()
    {
        return Ok(_applicationServiceProduto.GetAll());
    }

    // GET api/values/5
    [HttpGet("{id}")]
    public ActionResult<string> GetById(Guid id)
    {
        try
        {
            var produto = _applicationServiceProduto.GetById(id);

            if (produto == null)
                return NotFound();
            
            return Ok(produto);
        }
        catch (BadHttpRequestException e)
        {
            throw new BadHttpRequestException(e.Message);
        }
    }

    // POST api/values
    [HttpPost]
    public ActionResult Post([FromBody] ProdutoDTO produtoDTO)
    {
        try
        {
            if (produtoDTO == null)
                return NotFound();
            
            _applicationServiceProduto.Add(produtoDTO);
            return Ok("Produto cadastrado com sucesso");
        }
        catch (BadHttpRequestException e)
        {
            throw new BadHttpRequestException(e.Message);
        }
    }

    // PUT api/values/5
    [HttpPut]
    public ActionResult Put([FromBody] ProdutoDTO produtoDTO)
    {
        try
        {
            if (produtoDTO.Id == null)
                return NotFound();

            _applicationServiceProduto.Update(produtoDTO);
            return Ok("Produto atualizado com sucesso!");

        }
        catch (BadHttpRequestException e)
        {
            throw new BadHttpRequestException(e.Message);
        }
    }

    // DELETE api/values/5
    [HttpDelete()]
    public ActionResult Delete([FromBody] ProdutoDTO produtoDTO)
    {
        try
        {
            if (produtoDTO == null)
                return NotFound();

            _applicationServiceProduto.Remove(produtoDTO);
            return Ok("Produto removido com sucesso!");

        }
        catch (BadHttpRequestException e)
        {
            throw new BadHttpRequestException(e.Message);
        }
    }
}