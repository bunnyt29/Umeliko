namespace Umeliko.Application.Learning.Materials.Queries.ByCreator;

using AutoMapper;
using Common;
using Domain.Learning.Models.Materials;

public class MaterialByCreatorOutputModel : MaterialOutputModel
{
    public bool IsPublic { get; private set; }

    public override void Mapping(Profile mapper)
        => mapper
            .CreateMap<Material, MaterialByCreatorOutputModel>()
            .IncludeBase<Material, MaterialOutputModel>();
}
