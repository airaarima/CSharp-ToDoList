using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ToDoList.DTOs;
using ToDoList.Services;

namespace ToDoList.Controllers;

[Route("api/user")]
[ApiController]
[AllowAnonymous]
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

        return Created();
    }

    [HttpPost("login")]
    public async Task<IActionResult> LoginAsync(UserLoginDto user)
    {
        var response = await _service.LoginAsync(user);
        if (response == null) return BadRequest("Erro ao realizar login.");

        return Ok(new {accessToken = response});
    }
}
