using ToDoList.DTOs;
using ToDoList.Models;
using ToDoList.Repositories;


namespace ToDoList.Services;

public class UserService : IUserService
{
    private readonly IUserRepository _repository;
    public UserService(IUserRepository repository)
    {
        _repository = repository;
    }

    public async Task<int> CreateUserAsync(UserCreateDto newUser)
    {
        var userExists = await _repository.GetUserByUserNameAsync(newUser.UserName);
        if (userExists != null) return 0;

        var user = new User
        {
            Id = new Guid(),
            Name = newUser.Name,
            UserName = newUser.UserName,
            Password = newUser.Password
        };

        var response = await _repository.CreateUserAsync(user);
        return response == 1 ? 1 : 0;
    }

    public async Task<int> LoginAsync(UserLoginDto userLogin)
    {
        var userExists = await _repository.GetUserByUserNameAsync(userLogin.UserName);
        if (userExists == null) return 0;

        if (userExists.Password != userLogin.Password) return 0;

        return 1;
    }
}
