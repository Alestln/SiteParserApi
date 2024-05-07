using Core.Common;

namespace Core.Domain.RefactoringGuru.Models;

public class Article : Entity
{
    public int Id { get; private set; }
    
    public string Title { get; set; }

    public string Url { get; set; }

    public int? ArticleId { get; set; }
    
    public ICollection<Article>? InternalLinks { get; set; }
    
    private Article() { }
}