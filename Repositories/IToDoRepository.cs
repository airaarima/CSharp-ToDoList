using ToDoList.Models;

namespace ToDoList.Repositories;

public interface IToDoRepository
{
    Task<int> CreateToDoAsync(ToDoItem toDo);
    Task<int> UpdateToDoAsync(ToDoItem toDo);
    Task<int> DeleteToDoAsync(ToDoItem toDo);
    Task<IEnumerable<ToDoItem>> GetToDosByUserIdAsync(Guid userId);
    Task<ToDoItem> GetToDoByIdAndUserAsync(Guid id, Guid userId);
}
