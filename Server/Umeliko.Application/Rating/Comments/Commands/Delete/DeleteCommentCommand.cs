namespace Umeliko.Application.Rating.Comments.Commands.Delete;

using Common;
using Domain.Learning.Repositories;
using Domain.Rating.Repositories;
using MediatR;

public class DeleteCommentCommand : EntityCommand<int>, IRequest<Result>
{
    public string MaterialId { get; set; } = default!;

    public class DeleteCommentResourceCommandHandler(
            ICommentDomainRepository commentRepository,
            IMaterialDomainRepository materialRepository)
        : IRequestHandler<DeleteCommentCommand, Result>
    {
        public async Task<Result> Handle(
            DeleteCommentCommand request,
            CancellationToken cancellationToken)
        {
            var materialHasResource = await materialRepository.HasComment(
                request.MaterialId,
                request.Id,
                cancellationToken);

            if (!materialHasResource)
            {
                return materialHasResource;
            }

            return await commentRepository.Delete(
                request.Id,
                cancellationToken);
        }
    }
}
