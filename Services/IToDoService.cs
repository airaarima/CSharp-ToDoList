using ToDoList.DTOs;
using ToDoList.Models;

namespace ToDoList.Services;

public interface IToDoService
{
    Task<int> CreateToDoAsync(ToDoCreateDto toDo);
    Task<int> UpdateToDoAsync(ToDoUpdateDto toDo);
    Task<int> DeleteToDoAsync(Guid id);
    Task<IEnumerable<ToDoItem>> GetToDosAsync();
}
