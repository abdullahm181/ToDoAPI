using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Todo.API.Exceptions;
using Todo.Application.Mapping;
using Todo.Application.Queries.Categorys;
using Todo.Insfrastructure.Context;
using Todo.Insfrastructure.Interface;
using Todo.Insfrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

// Register GlobalExceptionHandler 
builder.Services.AddExceptionHandler<GlobalExceptionHandler>();
builder.Services.AddProblemDetails();

// Connection our local SQL Server
builder.Services.AddDbContext<TodoDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("TodoConnection"),
       b => b.MigrationsAssembly("Todo.Insfrastructure"));
} );
// Add services to the container.
builder.Services.AddScoped(typeof(IBaseRepository<>),typeof(BaseRepository<>));

// Register AutoMapper
//builder.Services.AddAutoMapper(typeof(MappingProfile).Assembly);// ini bersi lama karena harus pakai AutoMapper.Extensions.Microsoft.DependencyInjection
builder.Services.AddAutoMapper(cfg => cfg.AddProfile<MappingProfile>());

// Register MediatR untuk CQRSnya :  fitur utama dari MediatR, yaitu registrasi otomatis handler dari satu assembly :Karena MediatR hanya butuh satu titik referensi untuk mencari seluruh handler dalam satu assembly.
builder.Services.AddMediatR(m => m.RegisterServicesFromAssemblyContaining(typeof(GetAllTodoCategoriesQuery)));

// Register Swager
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Todo API",
        Version = "v1",
        Description = "ASP.NET Core Web API with CQRS and Clean Architecture"
    });

    // (Opsional) Jika pakai Authorization JWT
    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "Enter JWT token in format: Bearer {token}"
    });

    options.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            new string[] {}
        }
    });
});

var app = builder.Build();
// Use Middleware to handle GlobalExceptionHandler 
app.UseExceptionHandler(); 

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    //Aktifkan Swagger di middleware
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
