namespace Umeliko.Application.Learning.Materials.Queries.Mine;

using AutoMapper;
using Common;
using Domain.Learning.Models.Materials;

public class MineMaterialOutputModel : MaterialOutputModel
{
    public override void Mapping(Profile mapper)
        => mapper
            .CreateMap<Material, MineMaterialOutputModel>()
            .IncludeBase<Material, MaterialOutputModel>();
}
