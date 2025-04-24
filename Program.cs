using ToDoList.Infrastructure;
using Microsoft.EntityFrameworkCore;
using ToDoList.Services;
using ToDoList.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<IToDoListDbContext, ToDoListDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

builder.Services.AddScoped<IToDoRepository, ToDoRepository>();
builder.Services.AddScoped<IToDoService, ToDoService>();

builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserService, UserService>();

builder.Services.AddControllers();

var app = builder.Build();

app.UseHttpsRedirection();

app.MapControllers();

app.Run();