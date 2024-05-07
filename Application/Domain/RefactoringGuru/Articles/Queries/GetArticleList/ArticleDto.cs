namespace Application.Domain.RefactoringGuru.Articles.Queries.GetArticleList;

public record ArticleDto
{
    public string Title { get; set; }

    public string Url { get; set; }
}