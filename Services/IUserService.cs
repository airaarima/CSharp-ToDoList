using ToDoList.DTOs;

namespace ToDoList.Services;

public interface IUserService
{
    Task<int> CreateUserAsync(UserCreateDto newUser);
    Task<string> LoginAsync(UserLoginDto userLogin);
}
