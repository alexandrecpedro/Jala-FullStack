using DDDWebAPI.Application.DTO.DTO;
using DDDWebAPI.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace WebApiDDD.Presentation.Controllers;

[Route("[controller]")]
[ApiController]
public class ClientesController : ControllerBase
{
    private readonly IApplicationServiceCliente _applicationServiceCliente;

    public ClientesController(IApplicationServiceCliente ApplicationServiceCliente)
    {
        _applicationServiceCliente = ApplicationServiceCliente;
    }
    
    // GET api/values
    [HttpGet]
    public ActionResult<IEnumerable<string>> GetAll()
    {
        return Ok(_applicationServiceCliente.GetAll());
    }
    
    // GET api/values/5
    [HttpGet("{id}")]
    public ActionResult<string> GetById(Guid id)
    {
        try
        {
            var cliente = _applicationServiceCliente.GetById(id);

            if (cliente == null)
                return NotFound();
            
            return Ok(cliente);
        }
        catch (BadHttpRequestException e)
        {
            throw new BadHttpRequestException(e.Message);
        }
    }
    
    // POST api/values
    [HttpPost]
    public ActionResult Post([FromBody] ClienteDTO clienteDTO)
    {
        try
        {
            if (clienteDTO == null)
                return NotFound();

            _applicationServiceCliente.Add(clienteDTO);
            return Ok("Cliente cadastrado com sucesso!");
        }
        catch (BadHttpRequestException e)
        {
            throw new BadHttpRequestException(e.Message);
        }
    }
    
    // PUT api/values/5
    [HttpPut]
    public ActionResult Put([FromBody] ClienteDTO clienteDTO)
    {
        try
        {
            if (clienteDTO.Id == null)
                return NotFound();

            _applicationServiceCliente.Update(clienteDTO);
            return Ok("Cliente atualizado com sucesso!");
        }
        catch (BadHttpRequestException e)
        {
            throw new BadHttpRequestException(e.Message);
        }
    }
    
    // DELETE api/values/5
    [HttpDelete]
    public ActionResult Delete([FromBody] ClienteDTO clienteDTO)
    {
        try
        {
            if (clienteDTO == null)
                return NotFound();

            _applicationServiceCliente.Remove(clienteDTO);
            return Ok("Cliente removido com sucesso!");
        }
        catch (BadHttpRequestException e)
        {
            throw new BadHttpRequestException(e.Message);
        }
    }
}