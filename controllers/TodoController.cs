using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using todo.models;

namespace todo.controllers;

[Route("todo")]
public class TodoController(TodoContext todoContext) : ControllerBase
{
    private readonly TodoContext _todoContext = todoContext;

    [HttpGet()]
    public Task<string> GetAll()
    {
        var promise = new TaskCompletionSource<string>();
        promise.SetResult("Hello world");
        return promise.Task;
    }
}