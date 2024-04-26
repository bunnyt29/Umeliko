namespace Umeliko.Application.Learning.Follows.Queries;

using AutoMapper;
using Common.Mapping;
using Umeliko.Domain.Learning.Models.Creators;

public class FollowOutputModel : IMapFrom<Follow>
{
    public string FollowerId { get; private set; }

    public string CreatorId { get; private set; }

    public virtual void Mapping(Profile mapper)
        => mapper
            .CreateMap<Follow, FollowOutputModel>();
}
