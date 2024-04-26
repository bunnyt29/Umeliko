namespace Umeliko.Application.Learning.Banners.Commands.Edit;

using Common;
using Domain.Learning.Repositories;
using FluentValidation;

public class EditBannerCommandValidator : AbstractValidator<EditBannerCommand>
{
    public EditBannerCommandValidator(IBannerDomainRepository bannerRepository)
        => this.Include(new BannerCommandValidator<EditBannerCommand>(bannerRepository));
}
