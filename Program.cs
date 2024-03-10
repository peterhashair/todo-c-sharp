using Microsoft.EntityFrameworkCore;
using todo.configs;
using todo.models;
using todo.services;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();
builder.Services.AddScoped<TodoServices>();
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

