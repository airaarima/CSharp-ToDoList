using Microsoft.EntityFrameworkCore;
using ToDoList.Infrastructure;
using ToDoList.Models;

namespace ToDoList.Repositories;

public class UserRepository : IUserRepository
{
    private readonly IToDoListDbContext _context;

    public UserRepository(IToDoListDbContext context)
    {
        _context = context;
    }

    public async Task<int> CreateUserAsync(User user)
    {
        _context.User.Add(user);
        return await _context.SaveChangesAsync();
    }

    public async Task<User> GetUserByUserNameAsync(string userName, CancellationToken cancellationToken = default)
    {
        return await _context.User
        .FirstOrDefaultAsync(u => u.UserName == userName, cancellationToken);
    }
}
