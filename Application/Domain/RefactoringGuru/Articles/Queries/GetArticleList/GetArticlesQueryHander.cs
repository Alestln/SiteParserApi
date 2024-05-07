using AutoMapper;
using AutoMapper.QueryableExtensions;
using Core.Domain.RefactoringGuru.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using PagesResponse;
using Persistence.Contexts;

namespace Application.Domain.RefactoringGuru.Articles.Queries.GetArticleList;

public class GetArticlesQueryHander(RefactoringGuruDbContext context, IMapper mapper) 
    : IRequestHandler<GetArticlesQuery, PageResponse<ArticleDto[]>>
{
    public async Task<PageResponse<ArticleDto[]>> Handle(GetArticlesQuery request, CancellationToken cancellationToken)
    {
        var query = context.Articles.AsQueryable();

        if (!string.IsNullOrWhiteSpace(request.Order.Field))
        {
            query = ApplySorting(query, request.Order);
        }
        
        var articles = await query
            .Skip((request.Page - 1) * request.PageSize)
            .Take(request.PageSize)
            .ProjectTo<ArticleDto>(mapper.ConfigurationProvider)
            .ToArrayAsync(cancellationToken);

        return new PageResponse<ArticleDto[]>(articles.Length, articles);
    }
    
    private IQueryable<Article> ApplySorting(IQueryable<Article> query, SortOptions sortOptions)
    {
        switch (sortOptions.Field.ToLower())
        {
            case "title":
                query = sortOptions.Direction == SortDirections.Descending 
                    ? query.OrderByDescending(a => a.Title) 
                    : query.OrderBy(a => a.Title);
                break;
            case "url":
                query = sortOptions.Direction == SortDirections.Descending 
                    ? query.OrderByDescending(a => a.Url) 
                    : query.OrderBy(a => a.Url);
                break;
            default:
                throw new ArgumentException("Invalid sorting parameter.");
        }

        return query;
    }
}