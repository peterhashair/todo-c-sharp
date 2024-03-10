using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using todo.dtos.request;
using todo.dtos.response;
using todo.models;

namespace todo.services;

public class TodoServices(TodoContext todoContext)
{
    public async Task<List<TodoResponse>> GetTodos()
    {
        var todos = await todoContext.Todos.ToListAsync();

        return todos.Select(todo => new TodoResponse
            { id = todo.id, description = todo.description, title = todo.title, status = todo.status }).ToList();
    }

    public async Task<TodoResponse> GetById(Guid id)
    {
        var todo = await todoContext.Todos.Where(todo => todo.id == id).ToListAsync();

        var first = todo.First();
        return new TodoResponse
            { id = first.id, description = first.description, title = first.title, status = first.status };
    }


    public async Task<TodoResponse> Post(TodoPostRequest request)
    {
        var newItem = new Todo
        {
            description = request?.description,
            title = request.title,
            status = request.status
        };

        todoContext.Todos.Add(newItem);
        await todoContext.SaveChangesAsync();
        return new TodoResponse { id = newItem.id };
    }

    public async Task<TodoResponse> Put(Guid id, TodoPostRequest request)
    {
        var newItem = new Todo
        {
            id = id,
            description = request?.description,
            title = request.title,
            status = request.status
        };

        todoContext.Todos.Update(newItem);
        await todoContext.SaveChangesAsync();
        return new TodoResponse
            { id = newItem.id, description = newItem.description, title = newItem.title, status = newItem.status };
    }

    public async Task<Boolean> Delete(Guid id)
    {
        var deleteItem = await todoContext.Todos.FindAsync(id);
        if (deleteItem is null)
        {
            return false;
        }

        todoContext.Todos.Remove(deleteItem);
        await todoContext.SaveChangesAsync();
        return true;
    }
}