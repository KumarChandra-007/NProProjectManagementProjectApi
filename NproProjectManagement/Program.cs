using NproProjectManagement.Dapper;
using NproProjectManagement.Interfaces;
using NproProjectManagement.Model;
using NproProjectManagement.Repository;
using NproProjectManagement.Repository.Interface;
using NproProjectManagement.Services;

var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
                      policy =>
                      {
                          policy.WithOrigins("http://localhost:4200");
                      });
});

// Add services to the container.

builder.Services.AddSingleton<DapperContext>();
builder.Services.AddTransient<IProjectRepository, ProjectRepository>();
builder.Services.AddSingleton<IProjectService, ProjectService>();
builder.Services.AddSingleton<ProjectDetail>();


// Add services to the container.

builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseCors(MyAllowSpecificOrigins);
app.UseAuthorization();

app.MapControllers();

app.Run();
