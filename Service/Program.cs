using Microsoft.EntityFrameworkCore;
using Serilog;
using Service.Configuration;
using Service.Data;
using Service.Models;
using Service.Services;

var builder = WebApplication.CreateBuilder(args);

// Configure logging
Log.Logger = LoggingConfigurator.CreateConfiguration(builder.Configuration).CreateLogger();
Log.Information("Logging configured");

// Add services to the container.

builder.Services.ConfigurePostgreSql(builder.Configuration.GetSection("PostgreSql").Get<PostgreSqlConfiguration>());

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IBookService, BookService>();

// Setup mapper and mapping profiles.
MappingProfiles.SetupMapper();

var app = builder.Build();

// Configure the HTTP request pipeline.

if (app.Environment.IsDevelopment())
{
    Log.Information("Running in development mode");
}

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

// Migrate or run
if (args.Contains("--migrate"))
{
    Log.Information("Starting in database migration mode");
    using var serviceScope = app.Services.CreateScope();
    var context = serviceScope.ServiceProvider.GetService<DataContext>();
    if (context is null)
    {
        throw new ApplicationException("Fail to create database context");
    }
    
    context.Database.Migrate();
    Log.Information("Finished migrations. Exiting...");
}
else
{
    app.Run();
}