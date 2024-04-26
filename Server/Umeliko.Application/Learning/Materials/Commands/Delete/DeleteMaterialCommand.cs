namespace Umeliko.Application.Learning.Materials.Commands.Delete;

using Application.Common;
using Application.Common.Contracts;
using Common;
using Domain.Learning.Repositories;
using MediatR;

public class DeleteMaterialCommand : EntityCommand<string>, IRequest<Result>
{
    public class DeleteMaterialCommandHandler(
            ICurrentUser currentUser,
            ICreatorDomainRepository creatorRepository,
            IMaterialDomainRepository materialRepository)
        : IRequestHandler<DeleteMaterialCommand, Result>
    {
        public async Task<Result> Handle(
            DeleteMaterialCommand request,
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

            return await materialRepository.Delete(
                request.Id,
                cancellationToken);
        }
    }
}
