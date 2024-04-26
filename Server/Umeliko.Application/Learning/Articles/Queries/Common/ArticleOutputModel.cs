namespace Umeliko.Application.Learning.Articles.Queries.Common;

using Application.Common.Mapping;
using AutoMapper;
using Domain.Learning.Models.Materials;

public class ArticleOutputModel : IMapFrom<Article>
{
    public string Id { get; private set; } = default!;

    public string Content { get; private set; } = default!;

    public string MaterialId { get; set; } = default!;

    public virtual void Mapping(Profile mapper)
        => mapper
            .CreateMap<Article, ArticleOutputModel>();
}
