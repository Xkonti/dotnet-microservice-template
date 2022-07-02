using Microsoft.EntityFrameworkCore;
using Service.Data;

namespace Service.Configuration;

public readonly struct PostgreSqlConfiguration
{
    public string Host { get; init; }
    public string Port { get; init; }
    public string Database { get; init; }
    public string User { get; init; }
    public string Password { get; init; }

    public string ConnectionString
    {
        get
        {
            if (Database is null)
            {
                throw new InvalidOperationException("Missing PostgreSql:Database config value");
            }
            if (Host is null)
            {
                throw new InvalidOperationException("Missing PostgreSql:Host config value");
            }
            if (Port is null)
            {
                throw new InvalidOperationException("Missing PostgreSql:Port config value");
            }
            if (User is null)
            {
                throw new InvalidOperationException("Missing PostgreSql:User config value");
            }
            if (Password is null)
            {
                throw new InvalidOperationException("Missing PostgreSql:Password config value");
            }          
            
            return $"Host={Host};Port={Port};Database={Database};Username={User};Password={Password}";
        }
    }
}

public static class Configurator
{
    public static void ConfigurePostgreSql(this IServiceCollection services, PostgreSqlConfiguration config)
    {
        var connectionString = config.ConnectionString;
        
        // Configure EF connection to postgres
        services.AddDbContext<DataContext>(opt =>
        {
            opt.UseNpgsql(
                connectionString,
                b => b.MigrationsAssembly("Service")
            );
        });
    }
    
}