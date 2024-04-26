namespace Umeliko.Application.Learning.Banners.Commands.Create;

using Common;
using Domain.Learning.Repositories;
using FluentValidation;

public class CreateBannerCommandValidator : AbstractValidator<CreateBannerCommand>
{
    public CreateBannerCommandValidator(IBannerDomainRepository bannerRepository)
        => this.Include(new BannerCommandValidator<CreateBannerCommand>(bannerRepository));
}
