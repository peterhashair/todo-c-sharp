using todo.models;

namespace todo.dtos.response;

public class TodoResponse
{
    public Guid id { get; set; }
    public string title { get; set; }
    public Status status { get; set; }
    public string description { get; set; }
}