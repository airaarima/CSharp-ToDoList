using ToDoList.DTOs;
using ToDoList.Models;
using ToDoList.Repositories;

namespace ToDoList.Services;

public class ToDoService : IToDoService
{
    private readonly IToDoRepository _repository;
    public ToDoService(IToDoRepository repository)
    {
        _repository = repository;
    }

    public async Task<int> CreateToDoAsync(ToDoCreateDto toDo)
    {
        var todo = new ToDoItem
        {
            Id = new Guid(),
            Title = toDo.Title,
            Description = toDo.Description,
            IsCompleted = toDo.IsCompleted,
            Data = toDo.Data
        };

        var response = await _repository.CreateToDoAsync(todo);
        return response == 1 ? 1 : 0;
    }

    public async Task<int> DeleteToDoAsync(Guid id)
    {
        var todoExists = await _repository.GetToDoByIdAsync(id);
        if (todoExists == null) return 0;

        var response = await _repository.DeleteToDoAsync(todoExists);
        return response == 1 ? 1 : 0;
    }

    public async Task<IEnumerable<ToDoItem>> GetToDosAsync()
    {
        var todos = await _repository.GetToDosAsync();
        return todos;
    }

    public async Task<int> UpdateToDoAsync(ToDoUpdateDto toDo)
    {
        var todoExists = await _repository.GetToDoByIdAsync(toDo.Id);
        if(todoExists == null) return 0;

        todoExists.Title = toDo.Title ?? todoExists.Title;
        todoExists.Description = toDo.Description ?? todoExists.Description;
        todoExists.IsCompleted = toDo.IsCompleted ?? todoExists.IsCompleted;

        var response = await _repository.UpdateToDoAsync(todoExists);
        return response == 1 ? 1 : 0;
    }
}
