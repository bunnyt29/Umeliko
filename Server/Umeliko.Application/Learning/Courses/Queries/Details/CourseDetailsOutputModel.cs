namespace Umeliko.Application.Learning.Courses.Queries.Details;
using AutoMapper;
using Common;
using System.Collections.Generic;
using Umeliko.Application.Learning.Resources.Queries.Common;
using Umeliko.Domain.Learning.Models.Materials;

public class CourseDetailsOutputModel : CourseOutputModel
{
    public IEnumerable<ResourceOutputModel> Resources { get; set; } = new List<ResourceOutputModel>();

    public override void Mapping(Profile mapper)
        => mapper
            .CreateMap<Course, CourseDetailsOutputModel>()
            .IncludeBase<Course, CourseOutputModel>();
}
