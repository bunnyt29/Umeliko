namespace Umeliko.Application.Learning.Keywords.Queries.Common;

using Application.Common.Mapping;
using AutoMapper;
using Domain.Learning.Models.Materials;

public class KeywordOutputModel : IMapFrom<Keyword>
{
    public int Id { get; private set; }

    public string Name { get; set; } = default!;

    public virtual void Mapping(Profile mapper)
        => mapper
            .CreateMap<Keyword, KeywordOutputModel>();
}
