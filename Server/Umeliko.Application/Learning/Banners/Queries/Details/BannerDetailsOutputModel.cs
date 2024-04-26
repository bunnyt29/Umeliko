namespace Umeliko.Application.Learning.Banners.Queries.Details;

using AutoMapper;
using Common;
using Domain.Learning.Models.Materials;
using Keywords.Queries.Common;

public class BannerDetailsOutputModel : BannerOutputModel
{
    public IEnumerable<KeywordOutputModel> Keywords { get; set; } = new List<KeywordOutputModel>();

    public override void Mapping(Profile mapper)
    => mapper
            .CreateMap<Banner, BannerDetailsOutputModel>()
            .IncludeBase<Banner, BannerOutputModel>();
}
