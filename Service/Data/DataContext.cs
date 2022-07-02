using Microsoft.EntityFrameworkCore;
using Service.Models;

namespace Service.Data;

public class DataContext : DbContext
{
    // Register DbSets here
    public DbSet<Book> Books { get; set; }
    
    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {
    }

    /// <summary>
    /// Configure custom property converters
    /// </summary>
    /// <param name="configurationBuilder"></param>
    protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
    {
        // Register custom property converters here
        // configurationBuilder
        //     .Properties<Abc>()
        //     .HaveConversion<AbcConverter>();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Customize entities here
    }
    
    public override int SaveChanges(bool acceptAllChangesOnSuccess)
    {
        OnBeforeSaving();
        return base.SaveChanges(acceptAllChangesOnSuccess);
    }
    
    public override Task<int> SaveChangesAsync(
        bool acceptAllChangesOnSuccess,
        CancellationToken cancellationToken = default)
    {
        OnBeforeSaving();
        return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
    }
    
    private void OnBeforeSaving()
    {
        // Update auditable fields
        var entries = ChangeTracker.Entries();
        var utcNow = DateTime.UtcNow;

        foreach (var entry in entries)
        {
            // Update auditable fields
            if (entry.Entity is not IAuditable auditable) continue;
            switch (entry.State)
            {
                case EntityState.Added:
                    auditable.CreatedOn = utcNow;
                    auditable.UpdatedOn = utcNow;
                    break;
                case EntityState.Modified:
                    auditable.UpdatedOn = utcNow;
                    break;
            }
            
            if (entry.State != EntityState.Added)
            {
                // Prevent the "CreatedOn" field from being changed
                entry.Property("CreatedOn").IsModified = false;
            }
        }
    }
    
}