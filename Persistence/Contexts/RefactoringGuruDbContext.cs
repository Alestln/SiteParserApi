using Core.Domain.RefactoringGuru.Models;
using Microsoft.EntityFrameworkCore;
using Persistence.EntityConfigurations.RefactoringGuru;

namespace Persistence.Contexts;

public class RefactoringGuruDbContext(DbContextOptions<RefactoringGuruDbContext> options) : DbContext(options)
{
    internal const string DbSchema = "refactoring_guru";
    internal const string DbMigrationsHistoryTable = "__RefactoringGuruDbMigrationsHistory";
    
    public DbSet<Article> Articles { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema(DbSchema);
        
        modelBuilder.ApplyConfiguration(new ArticleConfiguration());
    }
}