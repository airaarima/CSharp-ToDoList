using Microsoft.EntityFrameworkCore;
using ToDoList.Models;

namespace ToDoList.Infrastructure;

public class ToDoListDbContext : DbContext, IToDoListDbContext
{
    public ToDoListDbContext(DbContextOptions<ToDoListDbContext> options) : base(options) { }

    public DbSet<User> User { get; set; }
    public DbSet<ToDoItem> ToDo { get; set; }

}
