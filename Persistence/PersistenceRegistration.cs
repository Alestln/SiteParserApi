using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Persistence.Contexts;

namespace Persistence;

public static class PersistenceRegistration
{
    private const string SiteParserConnectionStringName = "SiteParser";
    private const string NasaLogConnectionStringName = "Nasa";

    public static void AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
    {
        var siteParserConnectionString = configuration.GetConnectionString(SiteParserConnectionStringName)
                               ?? throw new AggregateException(
                                   $"Connection string '{SiteParserConnectionStringName}' is not found in configurations.");
        
        services.AddDbContext<RefactoringGuruDbContext>(options =>
        {
            options.UseNpgsql(
                siteParserConnectionString,
                npgsqlOptions =>
                {
                    npgsqlOptions.MigrationsHistoryTable(
                        RefactoringGuruDbContext.DbMigrationsHistoryTable,
                        RefactoringGuruDbContext.DbSchema);
                });
        });
        
        var nasaLogConnectionString = configuration.GetConnectionString(NasaLogConnectionStringName)
                                      ?? throw new AggregateException(
                                          $"Connection string '{NasaLogConnectionStringName}' is not found in configurations.");

        services.AddDbContext<NasaLogDbContext>(options =>
        {
            options.UseNpgsql(
                nasaLogConnectionString,
                npgsqlOptions =>
                {
                    npgsqlOptions.MigrationsHistoryTable(
                        NasaLogDbContext.DbMigrationsHistoryTable,
                        NasaLogDbContext.DbSchema);
                });
        });
    }
}