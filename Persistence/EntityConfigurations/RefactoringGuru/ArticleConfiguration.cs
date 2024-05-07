using Core.Domain.RefactoringGuru.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations.RefactoringGuru;

public class ArticleConfiguration : IEntityTypeConfiguration<Article>
{
    public void Configure(EntityTypeBuilder<Article> builder)
    {
        builder
            .HasMany(a => a.InternalLinks)
            .WithOne()
            .HasForeignKey(il => il.ArticleId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}