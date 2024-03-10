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
    private const string TableName = "todo";

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Todo>().ToTable(TableName).HasIndex(s => s.id);
    }
}

public class Todo
{
    public Guid id { get; set; }

    public required string title { get; set; }

    public string? description { get; set; }

    public Status status { get; set; }
}