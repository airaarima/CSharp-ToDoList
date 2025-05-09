using ToDoList.Models.User;
using ToDoList.Repositories;
using ToDoList.Utils;

namespace ToDoList.Services;

public class UserService : IUserService
{
    private readonly IUserRepository _repository;
    private readonly AuthService _authService;
    public UserService(IUserRepository repository, AuthService authService)
    {
        _repository = repository;
        _authService = authService;
    }

    public async Task<int> CreateUserAsync(UserCreateDto newUser)
    {
        var userExists = await _repository.GetUserByUserNameAsync(newUser.UserName);
        if (userExists != null) return 0;

        newUser.Password = PasswordHasher.HashPassword(newUser.Password);
        var user = User.CreateUser(newUser);

        var response = await _repository.CreateUserAsync(user);
        return response == 1 ? 1 : 0;
    }

    public async Task<string> LoginAsync(UserLoginDto userLogin)
    {
        var userExists = await _repository.GetUserByUserNameAsync(userLogin.UserName);
        if (userExists == null) return null;

        if (!PasswordHasher.VerifyPassword(userLogin.Password, userExists.Password)) return null;

        var token = _authService.GenerateJwtToken(userExists);

        return token;
    }
}
