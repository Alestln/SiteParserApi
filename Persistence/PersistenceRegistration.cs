using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Persistence.Contexts;

namespace Persistence;

public static class PersistenceRegistration
{
    private const string ConnectionStringName = "SiteParser";

    public static void AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString(ConnectionStringName)
                               ?? throw new AggregateException(
                                   $"Connection string '{ConnectionStringName}' is not found in configurations.");
        
        services.AddDbContext<RefactoringGuruDbContext>(options =>
        {
            options.UseNpgsql(
                connectionString,
                npgsqlOptions =>
                {
                    npgsqlOptions.MigrationsHistoryTable(
                        RefactoringGuruDbContext.DbMigrationsHistoryTable,
                        RefactoringGuruDbContext.DbSchema);
                });
        });
    }
}