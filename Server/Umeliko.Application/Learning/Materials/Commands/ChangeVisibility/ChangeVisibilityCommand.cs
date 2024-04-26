namespace Umeliko.Application.Learning.Materials.Commands.ChangeVisibility;

using Application.Common;
using Application.Common.Contracts;
using Common;
using Domain.Learning.Repositories;
using MediatR;

public class ChangeVisibilityCommand : EntityCommand<string>, IRequest<Result>
{
    public class ChangeVisibilityCommandHandler(
            ICurrentUser currentUser,
            IMaterialDomainRepository materialRepository,
            ICreatorDomainRepository creatorRepository)
        : IRequestHandler<ChangeVisibilityCommand, Result>
    {
        public async Task<Result> Handle(
            ChangeVisibilityCommand request,
            CancellationToken cancellationToken)
        {
            var creatorHasMaterial = await currentUser.CreatorHasMaterial(
                creatorRepository,
                request.Id,
                cancellationToken);

            if (!creatorHasMaterial)
            {
                return creatorHasMaterial;
            }

            var material = await materialRepository
                .Find(request.Id, cancellationToken);

            material.ChangeVisibility();

            await materialRepository.Update(material, cancellationToken);

            return Result.Success;
        }
    }
}
