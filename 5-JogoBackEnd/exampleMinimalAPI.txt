var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<TodoDb>(opt => opt.UseInMemoryDatabase("TodoList"));

var app = builder.Build();

app.MapPost("/addItem", async (TodoItem newItem, TodoDb db) =>
{
    await db.Todos.AddAsync(newItem);
    await db.SaveChangesAsync();
    return Results.Created($"/items/{newItem.Id}", newItem);
});

app.MapGet("/todoItems", async (TodoDb db) =>
    await db.Todos.ToListAsync());

app.MapGet("/todosItems/{id}", async (int id, TodoDb db) =>
    await db.Todos.FindAsync(id));

app.MapPut("/todosItems/{id}", async (int id, TodoItem inputTodo, TodoDb db) =>
{
    var todo = await db.Todos.FindAsync(id);
    if (todo == null) return Results.NotFound();
    todo.Name = inputTodo.Name;
    todo.IsComplete = inputTodo.IsComplete;
    await db.SaveChangesAsync();
    return Results.NotFound();
});

app.MapDelete("/todosItems/{id}", async (int id, TodoDb db) =>
{
    if (await db.Todos.FindAsync(id) is TodoItem todo)
    {
        db.Todos.Remove(todo);
        await db.SaveChangesAsync();
        return Results.NoContent();
    }
    return Results.NotFound();
});


app.MapGet("/", () => "Hello World!");

app.Run();
