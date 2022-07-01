using Serilog;
using Service.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Configure logging
Log.Logger = LoggingConfigurator.CreateConfiguration(builder.Configuration).CreateLogger();
Log.Information("Logging configured");

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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