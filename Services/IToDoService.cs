using ToDoList.Models.ToDoItem;

namespace ToDoList.Services;

public interface IToDoService
{
    Task<int> CreateToDoAsync(ToDoCreateDto toDo, Guid userId);
    Task<int> UpdateToDoAsync(ToDoUpdateDto toDo, Guid userId);
    Task<int> DeleteToDoAsync(Guid id, Guid userId);
    Task<IEnumerable<ToDoItem>> GetToDosByUserIdAsync(Guid userId);
}
