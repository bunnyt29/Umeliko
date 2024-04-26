namespace Umeliko.Application.Learning.Banners.Commands.Edit;

using Application.Common;
using Application.Common.Contracts;
using Application.Learning.Materials.Commands.Common;
using Common;
using Domain.Learning.Repositories;
using MediatR;

public class EditBannerCommand : BannerCommand<EditBannerCommand>, IRequest<Result>
{
    public class EditBannerCommandHandler(
            ICurrentUser currentUser,
            ICreatorDomainRepository creatorRepository,
            IBannerDomainRepository bannerRepository,
            IMaterialDomainRepository materialRepository)
        : IRequestHandler<EditBannerCommand, Result>
    {
        public async Task<Result> Handle(
            EditBannerCommand request,
            CancellationToken cancellationToken)
        {
            var creatorHasMaterial = await currentUser.CreatorHasMaterial(
                creatorRepository,
                request.MaterialId,
                cancellationToken);

            if (!creatorHasMaterial)
            {
                return creatorHasMaterial;
            }

            var materialHasBanner = await materialRepository.HasBanner(
                request.MaterialId,
                request.Id,
                cancellationToken);

            if (!materialHasBanner)
            {
                return materialHasBanner;
            }

            var banner = await bannerRepository
                .Find(request.Id, cancellationToken);

            banner
                .UpdateCoverImageUrl(request.CoverImageUrl)
                .UpdateTitle(request.Title)
                .UpdateDescription(request.Description)
                .UpdateCategory(request.Category)
                .UpdateLevel(request.Level);

            await bannerRepository.Update(banner, cancellationToken);

            return Result.Success;
        }
    }
}
