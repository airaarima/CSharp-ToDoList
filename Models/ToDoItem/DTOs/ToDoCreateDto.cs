namespace ToDoList.Models.ToDoItem;

public class ToDoCreateDto
{
    public string Title { get; set; }
    public string Description { get; set; }
    public bool IsCompleted { get; set; } = false;
    public DateTime Data { get; set; } = DateTime.Now;
}
