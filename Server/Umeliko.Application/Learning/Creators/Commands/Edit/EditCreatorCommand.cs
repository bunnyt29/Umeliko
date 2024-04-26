namespace Umeliko.Application.Learning.Creators.Commands.Edit;

using Common;
using Common.Contracts;
using Domain.Learning.Repositories;
using MediatR;

public class EditCreatorCommand : EntityCommand<string>, IRequest<Result>
{
    public string ImageUrl { get; set; } = default!;

    public string FirstName { get; set; } = default!;

    public string LastName { get; set; } = default!;

    public string? Bio { get; set; }

    public class EditCreatorCommandHandler(
            ICurrentUser currentUser,
            ICreatorDomainRepository creatorRepository)
        : IRequestHandler<EditCreatorCommand, Result>
    {
        public async Task<Result> Handle(
            EditCreatorCommand request,
            CancellationToken cancellationToken)
        {
            var creator = await creatorRepository.FindByUser(
                currentUser.UserId,
                cancellationToken);

            if (request.Id != creator.Id)
            {
                return "You cannot edit this creator.";
            }

            creator
                .UpdateImageUrl(request.ImageUrl)
                .UpdateFirstName(request.FirstName)
                .UpdateLastName(request.LastName)
                .UpdateBio(request.Bio);

            await creatorRepository.Update(creator, cancellationToken);

            return Result.Success;
        }
    }
}
