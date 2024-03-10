using Microsoft.AspNetCore.Mvc;
using todo.dtos.request;
using todo.dtos.response;
using todo.services;

namespace todo.controllers;

[Route("todo")]
[ApiController]
public class TodoController(TodoServices todoServices) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<List<TodoResponse>>> GetTodos()
    {
        return await todoServices.GetTodos();
    }

    [HttpGet("{id:guid}")]
    public async Task<ActionResult<TodoResponse>> GetById(Guid id)
    {
        return await todoServices.GetById(id);
    }

    [HttpPost]
    public async Task<ActionResult<TodoResponse>> Post(TodoPostRequest request)
    {
        return await todoServices.Post(request);
    }

    [HttpPut("{id:guid}")]
    public async Task<ActionResult<TodoResponse>> Post(Guid id, TodoPostRequest request)
    {
        return await todoServices.Put(id, request);
    }

    [HttpDelete("{id:guid}")]
    public async Task<ActionResult<TodoResponse>> Delete(Guid id)
    {
        var status = await todoServices.Delete(id);
        if (!status)
        {
            return NotFound();
        }

        return Ok();
    }
}