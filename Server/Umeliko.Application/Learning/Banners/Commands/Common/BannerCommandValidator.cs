namespace Umeliko.Application.Learning.Banners.Commands.Common;

using Application.Common;
using Domain.Learning.Repositories;
using FluentValidation;

using static Domain.Learning.Models.ModelConstants.Banner;

public class BannerCommandValidator<TCommand> : AbstractValidator<BannerCommand<TCommand>>
    where TCommand : EntityCommand<string>
{
    public BannerCommandValidator(IBannerDomainRepository bannerRepository)
    {
        this.RuleFor(b => b.Title)
            .MinimumLength(MinTitleLength)
            .MaximumLength(MaxTitleLength)
            .NotEmpty();

        this.RuleFor(b => b.Description)
            .MaximumLength(MaxDescriptionLength);
    }
}
