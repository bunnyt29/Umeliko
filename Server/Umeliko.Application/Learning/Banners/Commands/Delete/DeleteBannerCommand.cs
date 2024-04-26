namespace Umeliko.Application.Learning.Banners.Commands.Delete;

using Application.Common;
using Application.Common.Contracts;
using Domain.Learning.Repositories;
using Materials.Commands.Common;
using MediatR;

public class DeleteBannerCommand : EntityCommand<string>, IRequest<Result>
{
    public string MaterialId { get; set; }

    public class DeleteBannerCommandHandler(
            ICurrentUser currentUser,
            ICreatorDomainRepository creatorRepository,
            IBannerDomainRepository bannerRepository,
            IMaterialDomainRepository materialRepository)
        : IRequestHandler<DeleteBannerCommand, Result>
    {
        public async Task<Result> Handle(
            DeleteBannerCommand request,
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

            return await bannerRepository.Delete(
                request.Id,
                cancellationToken);
        }
    }
}
