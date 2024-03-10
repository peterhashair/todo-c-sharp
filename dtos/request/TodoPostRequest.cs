using System.ComponentModel.DataAnnotations;
using todo.models;

namespace todo.dtos.request;

public class TodoPostRequest
{
    public required string title { get; set; }

    public required Status status { get; set; }
    
    public string? description { get; set; }
}