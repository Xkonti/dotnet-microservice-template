using Serilog;
using Service.Configuration;
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
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();