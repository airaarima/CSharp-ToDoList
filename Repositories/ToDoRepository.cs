using Microsoft.EntityFrameworkCore;
using ToDoList.Infrastructure;
using ToDoList.Models.ToDoItem;

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

    public async Task<ToDoItem> GetToDoByIdAndUserAsync(Guid id, Guid userId)
    {
        return await _context.ToDo
                     .FirstOrDefaultAsync(t => t.Id == id && t.UserId == userId);
    }

    public async Task<IEnumerable<ToDoItem>> GetToDosByUserIdAsync(Guid userId)
    {
        return await _context.ToDo
            .Where(t => t.UserId == userId)
            .ToListAsync();
    }

    public async Task<int> UpdateToDoAsync(ToDoItem toDo)
    {
        _context.ToDo.Update(toDo);
        return await _context.SaveChangesAsync();
    }
}
