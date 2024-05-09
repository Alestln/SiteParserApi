using Microsoft.EntityFrameworkCore;

namespace Persistence.Contexts;

public class NasaLogDbContext(DbContextOptions<NasaLogDbContext> options) : DbContext(options)
{
    internal const string DbSchema = "logs";
    internal const string DbMigrationsHistoryTable = "__LogsDbMigrationsHistory";
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema(DbSchema);
    }
}