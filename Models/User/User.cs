namespace ToDoList.Models.User;

public class User
{
    private User(string name, string userName, string password)
    {
        Id = new Guid();
        Name = name;
        UserName = userName;
        Password = password;
    }

    public Guid Id { get; set; }
    public string Name { get; set; }
    public string UserName { get; set; }
    public string Password { get; set; }

    public static User CreateUser(UserCreateDto userDto)
    {
        var user = new User(userDto.UserName, userDto.UserName, userDto.Password);

        return user;
    }

    public ICollection<ToDoItem.ToDoItem> ToDos { get; set; }
}
