using Microsoft.EntityFrameworkCore;
using ToDoApi.Data;
using ToDoApi.DataService;

var builder = WebApplication.CreateBuilder(args);

IConfiguration _configuration = builder.Configuration;
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

#region DbContext Config

builder.Services.AddDbContext<AppDbContext>(option =>
{
    option.UseSqlite(_configuration["ConnectionStrings:Connection"]);
});

#endregion

builder.Services.AddTransient<ITodoService, ToDoService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
