using Application.Domain.RefactoringGuru.Articles.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers.RefactoringGuru;

[ApiController]
[Route("api/[controller]/[action]")]
public class ArticleController(IMediator mediator) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAllArticles(
        [FromQuery] int page = 1,
        [FromQuery] int pageSize = 10,
        CancellationToken cancellationToken = default)
    {
        var articles = 
            await mediator.Send(new GetArticlesQuery(page, pageSize), cancellationToken);

        return Ok(articles);
    }
}