using Microsoft.EntityFrameworkCore;
using todo.dtos.request;
using todo.dtos.response;
using todo.models;

namespace todo.services;

public class TodoServices(TodoContext todoContext)
{
    public async Task<List<TodoResponse>> GetAll()
    {
        var todos = await todoContext.Todos.ToListAsync();

        return todos.Select(todo => new TodoResponse
            { id = todo.id, description = todo.description, title = todo.title, status = todo.status }).ToList();
    }

    public TodoResponse GetById(Guid id)
    {
        var todo = todoContext.Todos.Where(todo => todo.id == id).ToList().First();

        return new TodoResponse
            { id = todo.id, description = todo.description, title = todo.title, status = todo.status };
    }


    public async Task<TodoResponse> Post(TodoPostRequest? request)
    {
        var newItem = new Todo
        {
            description = request.description,
            title = request.title,
            status = request.status
        };

        todoContext.Todos.Add(newItem);
        await todoContext.SaveChangesAsync();
        return new TodoResponse { id = newItem.id };
    }

    public bool Delete()
    {
        return true;
    }
}