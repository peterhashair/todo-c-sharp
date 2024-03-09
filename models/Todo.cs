using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices;
using Microsoft.EntityFrameworkCore;

namespace todo.models;
public enum Status
{
     Done,
     Ingress,
     Cancel,
     Todo,
}

public class TodoContext(DbContextOptions<TodoContext> options) : DbContext(options)
{
    public DbSet<Todo> Todos { get; set; }
}
public class Todo
{
    public int id { get; set; }

    public string title { get; set; }

    public string description { get; set; }

    public Status status { get; set; }
   
}