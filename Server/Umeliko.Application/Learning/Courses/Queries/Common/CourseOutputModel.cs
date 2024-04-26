namespace Umeliko.Application.Learning.Courses.Queries.Common;

using AutoMapper;
using Umeliko.Application.Common.Mapping;
using Umeliko.Domain.Learning.Models.Materials;

public class CourseOutputModel : IMapFrom<Course>
{
    public string Id { get; private set; } = default!;

    public string? Content { get; private set; }

    public string MaterialId { get; set; } = default!;

    public virtual void Mapping(Profile mapper)
        => mapper
            .CreateMap<Course, CourseOutputModel>();
}
