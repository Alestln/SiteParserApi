using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using PagesResponse;
using Persistence.Contexts;

namespace Application.Domain.RefactoringGuru.Articles.Queries;

public class GetArticlesQueryHander(RefactoringGuruDbContext context, IMapper mapper) 
    : IRequestHandler<GetArticlesQuery, PageResponse<ArticleDto[]>>
{
    public async Task<PageResponse<ArticleDto[]>> Handle(GetArticlesQuery request, CancellationToken cancellationToken)
    {
        var articles = await context.Articles
            .Where(a => a.ArticleId == null)
            .ProjectTo<ArticleDto>(mapper.ConfigurationProvider)
            .ToArrayAsync(cancellationToken);

        return new PageResponse<ArticleDto[]>(articles.Length, articles);
    }
}