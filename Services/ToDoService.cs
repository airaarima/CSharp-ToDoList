using ToDoList.Models.ToDoItem;
using ToDoList.Repositories;

namespace ToDoList.Services;

public class ToDoService : IToDoService
{
    private readonly IToDoRepository _repository;
    public ToDoService(IToDoRepository repository)
    {
        _repository = repository;
    }

    public async Task<int> CreateToDoAsync(ToDoCreateDto toDo, Guid userId)
    {
        var todo = ToDoItem.CreateTodoItem(toDo, userId);

        var response = await _repository.CreateToDoAsync(todo);
        return response == 1 ? 1 : 0;
    }

    public async Task<int> DeleteToDoAsync(Guid id, Guid userId)
    {
        var todoExists = await _repository.GetToDoByIdAndUserAsync(id, userId);
        if (todoExists == null) return 0;

        var response = await _repository.DeleteToDoAsync(todoExists);
        return response == 1 ? 1 : 0;
    }

    public async Task<IEnumerable<ToDoItem>> GetToDosByUserIdAsync(Guid userId)
    {
        var todos = await _repository.GetToDosByUserIdAsync(userId);
        return todos;
    }

    public async Task<int> UpdateToDoAsync(ToDoUpdateDto toDo, Guid userId)
    {
        var todoExists = await _repository.GetToDoByIdAndUserAsync(toDo.Id, userId);
        if(todoExists == null) return 0;

        todoExists.Title = toDo.Title ?? todoExists.Title;
        todoExists.Description = toDo.Description ?? todoExists.Description;
        if (toDo.IsCompleted ?? false) todoExists.Complete();

        var response = await _repository.UpdateToDoAsync(todoExists);
        return response == 1 ? 1 : 0;
    }
}
