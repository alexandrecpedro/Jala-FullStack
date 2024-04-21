using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using ToDoList.Models;
using ToDoList.Models.DTOs;
using ToDoList.UseCases.Interfaces;

namespace ToDoList.Controllers;

[ApiController]
[Route("api/v1/todo")]
public class ToDoController : ControllerBase
{
    [HttpPost]
    [Route("")]
    [ProducesResponseType(typeof(ToDoDto), StatusCodes.Status201Created)]
    [SwaggerOperation(Description = "Submit a ToDo")]
    public async Task<IActionResult> Create([FromBody] CreateToDoDto createToDoDTO, [FromServices] ICreateUseCase<ToDoItem> toDoService,
        [FromServices] IMapper mapper)
    {
        var toDo = mapper.Map<ToDoItem>(createToDoDTO);
        var createdToDo = await toDoService.Execute(toDo);
        var toDoDto = mapper.Map<ToDoDto>(createdToDo);
        return CreatedAtAction(nameof(Get), new { id = toDoDto.Id }, toDoDto);
    }
    
    [HttpDelete]
    [Route("{id:guid:required}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [SwaggerOperation(Description = "Delete a ToDo identified by its id")]
    public async Task<IActionResult> Delete(Guid id, [FromServices] IDeleteUseCase<ToDoItem> toDoService)
    {
        await toDoService.Execute(id);

        return NoContent();
    }
    
    [HttpGet]
    [Route("{id:guid:required}")]
    [ProducesResponseType(typeof(ToDoDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [SwaggerOperation(Description = "Retrieve a ToDo identified by its id")]
    public async Task<IActionResult> Get([FromRoute] Guid id, [FromServices] IGetByIdUseCase<ToDoItem> toDoService,
        [FromServices] IMapper mapper)
    {
        var toDo = await toDoService.Execute(id);

        return Ok(mapper.Map<ToDoDto>(toDo));
    }
    
    [HttpGet]
    [Route("")]
    [ProducesResponseType(typeof(ToDoDto[]), StatusCodes.Status200OK)]
    [SwaggerOperation(Description = "Retrieve all ToDos")]
    public async Task<IActionResult> GetAll([FromServices] IGetAllUseCase<ToDoItem> toDoService,
        [FromServices] IMapper mapper)
    {
        var toDos = await toDoService.Execute();

        return Ok(mapper.Map<ToDoDto[]>(toDos));
    }
    
    [HttpPut]
    [Route("{id:guid:required}")]
    [ProducesResponseType(typeof(ToDoDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [SwaggerOperation(Description = "Update a ToDo identified by its id")]
    public async Task<IActionResult> Update(Guid id, [FromBody] UpdateToDoDto updateToDoDto,
        [FromServices] IUpdateUseCase<ToDoItem> toDoService,
        [FromServices] IMapper mapper)
    {
        var toDo = mapper.Map<ToDoItem>(updateToDoDto);

        var updatedToDo = await toDoService.Execute(id, toDo);

        var toDoDto = mapper.Map<ToDoDto>(updatedToDo);

        return Ok(toDoDto);
    }
}