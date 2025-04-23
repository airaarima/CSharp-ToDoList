using Microsoft.EntityFrameworkCore;
using ToDoList.Models;

namespace ToDoList.Infrastructure;

public interface IToDoListDbContext
{
    DbSet<User> User { get; set; }
    DbSet<ToDoItem> ToDo { get; set; }
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}
