using Microsoft.AspNetCore.Mvc;
using ToDoList.DTOs;
using ToDoList.Services;

namespace ToDoList.Controllers
{
    [Route("api/user")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _service;

        public UserController(IUserService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> CreateUserAsync(UserCreateDto user)
        {
            var response = await _service.CreateUserAsync(user);
            if (response == 0) return BadRequest("Não foi possível criar o usuário.");

            return Ok("Usuário criado com sucesso");
        }
    }
}
