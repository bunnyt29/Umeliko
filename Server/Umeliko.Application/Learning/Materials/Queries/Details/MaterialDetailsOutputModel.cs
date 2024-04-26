namespace Umeliko.Application.Learning.Materials.Queries.Details;

using Articles.Queries.Common;
using AutoMapper;
using Common;
using Domain.Learning.Models.Materials;
using Lessons.Queries.Common;

public class MaterialDetailsOutputModel : MaterialOutputModel
{
    public ArticleOutputModel Article { get; set; } = default!;

    public LessonOutputModel Lesson { get; set; } = default!;

    public override void Mapping(Profile mapper)
        => mapper
            .CreateMap<Material, MaterialDetailsOutputModel>()
            .IncludeBase<Material, MaterialOutputModel>();
}
