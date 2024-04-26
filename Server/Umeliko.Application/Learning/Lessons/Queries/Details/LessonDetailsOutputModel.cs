namespace Umeliko.Application.Learning.Lessons.Queries.Details;

using AutoMapper;
using Common;
using Domain.Learning.Models.Materials;
using Resources.Queries.Common;

public class LessonDetailsOutputModel : LessonOutputModel
{
    public IEnumerable<ResourceOutputModel> Resources { get; set; } = new List<ResourceOutputModel>();

    public override void Mapping(Profile mapper)
        => mapper
            .CreateMap<Lesson, LessonDetailsOutputModel>()
            .IncludeBase<Lesson, LessonOutputModel>();
}
