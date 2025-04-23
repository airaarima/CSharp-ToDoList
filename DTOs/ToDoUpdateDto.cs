namespace ToDoList.DTOs;

public class ToDoUpdateDto
{
    public string Title { get; set; }
    public string Description { get; set; }
    public bool IsCompleted { get; set; }
}
