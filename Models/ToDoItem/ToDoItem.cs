namespace ToDoList.Models.ToDoItem;

public class ToDoItem
{
    private ToDoItem(string title, string description, Guid userId)
    {
        Id = Guid.NewGuid();
        Title = title;
        Description = description;
        Date = DateTime.Now;
        UserId = userId;
    }

    public Guid Id { get; private set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public bool IsCompleted { get; private set; }
    public DateTime Date { get; private set; }
    public DateTime DateCompleted { get; private set; }

    public Guid UserId { get; private set; }
    public virtual User.User User { get; private set; }

    public static ToDoItem CreateTodoItem(ToDoCreateDto createTodo, Guid userId)
    {
        var todo = new ToDoItem(
            createTodo.Title,
            createTodo.Description,
            userId);

        if (createTodo.IsCompleted)
            todo.Complete();

        return todo;
    }

    public void Complete()
    {
        IsCompleted = true;
        DateCompleted = DateTime.Now;
    }
}