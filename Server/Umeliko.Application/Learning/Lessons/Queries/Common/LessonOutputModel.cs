namespace Umeliko.Application.Learning.Lessons.Queries.Common;

using Application.Common.Mapping;
using AutoMapper;
using Domain.Learning.Models.Materials;

public class LessonOutputModel : IMapFrom<Lesson>
{
    public string Id { get; private set; } = default!;

    public string? Content { get; private set; }

    public string? FileUrl { get; private set; }

    public string MaterialId { get; set; } = default!;

    public virtual void Mapping(Profile mapper)
        => mapper
            .CreateMap<Lesson, LessonOutputModel>();
}
