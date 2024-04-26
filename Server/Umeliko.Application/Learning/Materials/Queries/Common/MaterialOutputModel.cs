namespace Umeliko.Application.Learning.Materials.Queries.Common;

using Application.Common.Mapping;
using AutoMapper;
using Banners.Queries.Common;
using Creators.Queries.Details;
using Domain.Common.Models;
using Domain.Learning.Models.Materials;
using Rating.Comments.Queries.Common;
using Rating.Votes.Queries.Common;

public class MaterialOutputModel : IMapFrom<Material>
{
    public string Id { get; private set; } = default!;

    public string ContentType { get; private set; } = default!;

    public int StateType { get; private set; }

    public CreatorDetailsOutputModel Creator { get; set; } = default!;

    public BannerOutputModel Banner { get; set; } = default!;

    public IEnumerable<VoteOutputModel> Votes { get; set; } = new List<VoteOutputModel>();

    public IEnumerable<CommentOutputModel> Comments { get; set; } = new List<CommentOutputModel>();

    public virtual void Mapping(Profile mapper)
        => mapper
            .CreateMap<Material, MaterialOutputModel>()
            .ForMember(m => m.ContentType, cfg => cfg
                .MapFrom(m => Enumeration.NameFromValue<ContentType>(
                    m.ContentType.Value)))
            .ForMember(m => m.StateType, cfg => cfg
                .MapFrom(m => m.StateType.Value));
}
