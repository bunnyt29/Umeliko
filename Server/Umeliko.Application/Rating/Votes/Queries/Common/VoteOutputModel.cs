namespace Umeliko.Application.Rating.Votes.Queries.Common;

using AutoMapper;
using Domain.Rating.Models.Votes;
using Umeliko.Application.Common.Mapping;

public class VoteOutputModel : IMapFrom<Vote>
{
    public int Id { get; set; }

    public int VoteType { get; set; }

    public string CreatorId { get; private set; } = default!;

    public virtual void Mapping(Profile mapper)
        => mapper
            .CreateMap<Vote, VoteOutputModel>()
            .ForMember(v => v.VoteType, cfg => cfg
                .MapFrom(v => v.VoteType.Value));
}
