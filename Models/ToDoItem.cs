namespace ToDoList.Models;

public class ToDoItem
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public bool IsCompleted { get; set; }
    public DateTime Data {  get; set; }

    public Guid UserId { get; set; }
    public User User { get; set; }
}
