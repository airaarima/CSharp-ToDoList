using ToDoList.Models.User;

namespace ToDoList.Repositories;

public interface IUserRepository
{
    Task<int> CreateUserAsync(User user);
    Task<User> GetUserByUserNameAsync(string userName, CancellationToken cancellationToken = default);
}
