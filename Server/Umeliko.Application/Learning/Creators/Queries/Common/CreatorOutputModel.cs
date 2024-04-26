namespace Umeliko.Application.Learning.Creators.Queries.Common;

using Application.Common.Mapping;
using AutoMapper;
using Domain.Learning.Models.Creators;

public class CreatorOutputModel : IMapFrom<Creator>
{
    public string Id { get; private set; } = default!;

    public string ImageUrl { get; set; } = default!;

    public string UserName { get; set; } = default!;

    public string FirstName { get; private set; } = default!;

    public string LastName { get; private set; } = default!;

    public virtual void Mapping(Profile mapper)
    => mapper
        .CreateMap<Creator, CreatorOutputModel>();

}
