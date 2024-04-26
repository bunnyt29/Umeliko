namespace Umeliko.Application.Rating.Comments.Queries.Common;

using Application.Common.Mapping;
using AutoMapper;
using Domain.Rating.Models.Comments;
using Learning.Creators.Queries.Common;

public class CommentOutputModel : IMapFrom<Comment>
{
    public int Id { get; set; }

    public string Content { get; set; } = default!;

    public string CreatorId { get; private set; } = default!;

    public CreatorOutputModel Creator { get; set; } = default!;

    public virtual void Mapping(Profile mapper)
        => mapper
            .CreateMap<Comment, CommentOutputModel>();
}
