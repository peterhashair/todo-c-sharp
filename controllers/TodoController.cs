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
    public async Task<ActionResult<List<TodoResponse>>> GetAll()
    {
        return await todoServices.GetAll();
    }

    [HttpPost]
    public async Task<ActionResult<TodoResponse>> Post(TodoPostRequest request)
    {
        return await todoServices.Post(request);;
    }
}