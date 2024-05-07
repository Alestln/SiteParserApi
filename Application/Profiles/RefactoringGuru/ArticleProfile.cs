using Application.Domain.RefactoringGuru.Articles.Queries;
using AutoMapper;
using Core.Domain.RefactoringGuru.Models;

namespace Application.Profiles.RefactoringGuru;

public class ArticleProfile : Profile
{
    public ArticleProfile()
    {
        CreateProjection<Article, ArticleDto>();
    }
}