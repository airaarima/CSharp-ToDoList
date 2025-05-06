using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using ToDoList.DTOs;
using ToDoList.Services;

namespace ToDoList.Controllers;

[Route("api/todo")]
[ApiController]
[Authorize]
public class ToDoController : ControllerBase
{
    private readonly IToDoService _service;

    public ToDoController(IToDoService service) 
    { 
        _service = service;
    }

    private Guid GetUserId()
    {
        var idStr = User.FindFirstValue(ClaimTypes.NameIdentifier);
        return Guid.TryParse(idStr, out var id)
            ? id
            : throw new UnauthorizedAccessException();
    }


    [HttpPost]
    public async Task<IActionResult> CreateToDoAsync(ToDoCreateDto toDo)
    {
        var userId = GetUserId();

        var response = await _service.CreateToDoAsync(toDo, userId);
        if (response == 0) return BadRequest("Não foi possível criar a tarefa.");

        return Ok();
    }

    [HttpPut]
    public async Task<IActionResult> UpdateToDoAsync(ToDoUpdateDto toDo)
    {
        var userId = GetUserId();

        var response = await _service.UpdateToDoAsync(toDo, userId);
        if (response == 0) return BadRequest("Erro ao atualizar tarefa.");

        return NoContent();
    }

    [HttpDelete]
    public async Task<IActionResult> DeleteToDoAsync([FromQuery] Guid id)
    {
        var userId = GetUserId();

        var response = await _service.DeleteToDoAsync(id, userId);
        if(response == 0) return BadRequest("Erro ao excluir tarefa.");

        return Ok("Tarefa excluída com sucesso!");
    }

    [HttpGet]
    public async Task<IActionResult> GetToDosAsync()
    {
        var userId = GetUserId();

        var response = await _service.GetToDosByUserIdAsync(userId);
        if(response.IsNullOrEmpty()) return BadRequest("Tarefas não foram encontradas");

        return Ok(response);
    }
}
