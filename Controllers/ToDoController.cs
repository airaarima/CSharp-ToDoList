using Microsoft.AspNetCore.Mvc;
using ToDoList.DTOs;
using ToDoList.Services;

namespace ToDoList.Controllers
{
    [Route("api/todo")]
    [ApiController]
    public class ToDoController : ControllerBase
    {
        private readonly IToDoService _service;

        public ToDoController(IToDoService service) 
        { 
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> CreateToDoAsync(ToDoCreateDto toDo)
        {
            var response = await _service.CreateToDoAsync(toDo);
            if (response == 0) return BadRequest("Não foi possível criar a tarefa.");

            return Created();
        }

        [HttpPut]
        public async Task<IActionResult> UpdateToDoAsync(ToDoUpdateDto toDo)
        {
            var response = await _service.UpdateToDoAsync(toDo);
            if (response == 0) return BadRequest("Erro ao atualizar tarefa.");

            return Ok("Tarefa atualizada com sucesso!");
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteToDoAsync([FromQuery] Guid id)
        {
            var response = await _service.DeleteToDoAsync(id);
            if(response == 0) return BadRequest("Erro ao excluir tarefa.");

            return Ok("Tarefa excluída com sucesso!");
        }

        [HttpGet]
        public async Task<IActionResult> GetToDosAsync()
        {
            var response = await _service.GetToDosAsync();
            if(response == null) return BadRequest("Tarefas não foram encontradas");

            return Ok(response);
        }
    }
}
