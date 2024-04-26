namespace Umeliko.Application.Learning.Articles.Queries.Details;

using Application.Learning.Resources.Queries.Common;
using AutoMapper;
using Common;
using Domain.Learning.Models.Materials;

public class ArticleDetailsOutputModel : ArticleOutputModel
{
    public IEnumerable<ResourceOutputModel> Resources { get; set; } = new List<ResourceOutputModel>();

    public override void Mapping(Profile mapper)
        => mapper
            .CreateMap<Article, ArticleDetailsOutputModel>()
            .IncludeBase<Article, ArticleOutputModel>();
}
