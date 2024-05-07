using MediatR;
using PagesResponse;

namespace Application.Domain.RefactoringGuru.Articles.Queries;

public record GetArticlesQuery(int Page, int PageSize, SortOptions Order) : IRequest<PageResponse<ArticleDto[]>>;