namespace Umeliko.Application.Learning.Resources.Queries.Common;

using Application.Common.Mapping;
using AutoMapper;
using Domain.Learning.Models.Materials;

public class ResourceOutputModel : IMapFrom<Resource>
{
    public int Id { get; set; }

    public string? FileUrl { get; set; }

    public string? ArticleId { get; set; }

    public string? LessonId { get; set; }

    public string? CourseId { get; set; }

    public virtual void Mapping(Profile mapper)
        => mapper
            .CreateMap<Resource, ResourceOutputModel>();
}
