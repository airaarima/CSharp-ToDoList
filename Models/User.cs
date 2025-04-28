namespace ToDoList.Models;

public class User
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string UserName { get; set; }
    public string Password { get; set; }

    public ICollection<ToDoItem> ToDos { get; set; }
}
