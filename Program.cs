using Microsoft.EntityFrameworkCore;
using todo.models;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();
var db = builder.Configuration.GetSection("DB").Get<DbConfig>();
builder.Services.AddDbContext<TodoContext>(options =>
    options.UseNpgsql($"Host={db.host};Database={db.database};Username={db.username};Password={db.password}"));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.MapControllers();
app.UseRouting();
app.Run();

public struct DbConfig
{
    public string host { get; }
    public string username { get; }
    public string password { get; }
    public string database { get; }
}