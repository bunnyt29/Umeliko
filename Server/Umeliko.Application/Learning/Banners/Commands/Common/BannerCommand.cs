namespace Umeliko.Application.Learning.Banners.Commands.Common;

using Application.Common;

public abstract class BannerCommand<TCommand> : EntityCommand<string>
    where TCommand : EntityCommand<string>
{
    public string CoverImageUrl { get; set; } = default!;

    public string Title { get; set; } = default!;

    public string? Description { get; set; }

    public string Category { get; set; } = default!;

    public string Level { get; set; } = default!;

    public string MaterialId { get; set; } = default!;
}
