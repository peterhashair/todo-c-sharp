using System.ComponentModel.DataAnnotations;
using todo.models;

namespace todo.dtos.request;

public class TodoPostRequest
{
    public string title { get; set; }

    [Required]
    public Status status { get; set; }
    
    public string? description { get; set; }
}