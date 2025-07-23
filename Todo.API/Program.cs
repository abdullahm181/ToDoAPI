using Microsoft.EntityFrameworkCore;
using Todo.Insfrastructure.Context;
using Todo.Insfrastructure.Interface;
using Todo.Insfrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

// Connection our local SQL Server
builder.Services.AddDbContext<TodoDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("TodoConnection"),
       b => b.MigrationsAssembly("Todo.Insfrastructure"));
} );
// Add services to the container.
builder.Services.AddScoped(typeof(IBaseRepository<>),typeof(BaseRepository<>));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
