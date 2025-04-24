using Microsoft.EntityFrameworkCore;
using ToDoList.Infrastructure;
using ToDoList.Models;

namespace ToDoList.Repositories;

public class ToDoRepository : IToDoRepository
{
    private readonly IToDoListDbContext _context;

    public ToDoRepository(IToDoListDbContext context)
    {
        _context = context;
    }

    public async Task<int> CreateToDoAsync(ToDoItem toDo)
    {
        _context.ToDo.Add(toDo);
        return await _context.SaveChangesAsync();
    }

    public async Task<int> DeleteToDoAsync(ToDoItem toDo)
    {
        _context.ToDo.Remove(toDo);
        return await _context.SaveChangesAsync();

    }

    public async Task<ToDoItem> GetToDoByIdAsync(Guid id)
    {
        return await _context.ToDo.FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<IEnumerable<ToDoItem>> GetToDosAsync()
    {
        return await _context.ToDo.ToListAsync();
    }

    public async Task<int> UpdateToDoAsync(ToDoItem toDo)
    {
        _context.ToDo.Update(toDo);
        return await _context.SaveChangesAsync();
    }
}
