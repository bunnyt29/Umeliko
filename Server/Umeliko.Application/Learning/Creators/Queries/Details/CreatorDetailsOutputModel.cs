namespace Umeliko.Application.Learning.Creators.Queries.Details;

using AutoMapper;
using Common;
using Domain.Learning.Models.Creators;

public class CreatorDetailsOutputModel : CreatorOutputModel
{
    public string Email { get; set; } = default!;

    public string? Bio { get; private set; }

    public IList<CreatorOutputModel> Following { get; set; } = new List<CreatorOutputModel>();

    public IList<CreatorOutputModel> Followers { get; set; } = new List<CreatorOutputModel>();

    public override void Mapping(Profile mapper)
        => mapper
            .CreateMap<Creator, CreatorDetailsOutputModel>()
            .IncludeBase<Creator, CreatorOutputModel>();
}
