using Application.Domain.RefactoringGuru.Articles.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using PagesResponse;

namespace Api.Controllers.RefactoringGuru;

[ApiController]
[Route("api/[controller]/[action]")]
public class ArticleController(IMediator mediator) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAllArticles(
        [FromQuery] int page,
        [FromQuery] int pageSize,
        [FromQuery] string sortField,
        [FromQuery] string sortDirection = SortDirections.Ascending,
        CancellationToken cancellationToken = default)
    {
        var articles = 
            await mediator.Send(new GetArticlesQuery(page, pageSize, new SortOptions(sortField, sortDirection)), 
                cancellationToken);

        return Ok(articles);
    }
}