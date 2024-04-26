namespace Umeliko.Application.Learning.Banners.Commands.Create;

using Common;
using Domain.Learning.Factories.Materials;
using Domain.Learning.Repositories;
using MediatR;

public class CreateBannerCommand : BannerCommand<CreateBannerCommand>, IRequest<CreateBannerOutputModel>
{
    public class CreateBannerCommandHandler(
            IMaterialDomainRepository materialRepository,
            IBannerDomainRepository bannerRepository,
            IBannerFactory bannerFactory)
        : IRequestHandler<CreateBannerCommand, CreateBannerOutputModel>
    {
        public async Task<CreateBannerOutputModel> Handle(
            CreateBannerCommand request,
            CancellationToken cancellationToken)
        {
            var material = await materialRepository.Find(
                request.MaterialId,
                cancellationToken);

            if (material == null)
            {
                return null;
            }

            var banner = bannerFactory
                .WithCoverImageUrl(request.CoverImageUrl)
                .WithTitle(request.Title)
                .WithDescription(request.Description)
                .WithCategory(request.Category)
                .WithLevel(request.Level)
                .WithMaterialId(material.Id)
                .Build();

            await bannerRepository.Save(banner, cancellationToken);

            return new CreateBannerOutputModel(banner.Id);
        }
    }
}
