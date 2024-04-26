namespace Umeliko.Application.Learning.Banners.Queries.Common;

using Application.Common.Mapping;
using AutoMapper;
using Domain.Learning.Models.Materials;

public class BannerOutputModel : IMapFrom<Banner>
{
    public string Id { get; private set; } = default!;

    public string CoverImageUrl { get; private set; } = default!;

    public string Title { get; private set; } = default!;

    public string? Description { get; private set; }

    public string Category { get; private set; } = default!;

    public string Level { get; private set; } = default!;

    public string MaterialId { get; set; } = default!;

    public virtual void Mapping(Profile mapper)
        => mapper
            .CreateMap<Banner, BannerOutputModel>();
}
