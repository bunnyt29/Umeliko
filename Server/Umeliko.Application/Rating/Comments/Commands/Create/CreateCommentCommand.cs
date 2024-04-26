namespace Umeliko.Application.Rating.Comments.Commands.Create;

using Common;
using Common.Contracts;
using Domain.Learning.Repositories;
using Domain.Rating.Models.Comments;
using Domain.Rating.Repositories;
using MediatR;

public class CreateCommentCommand : EntityCommand<int>, IRequest<CreateCommentOutputModel>
{
    public string Content { get; set; } = default!;

    public string MaterialId { get; set; } = default!;

    public class CreateCommentCommandHandler(
            ICurrentUser currentUser,
            ICreatorDomainRepository creatorRepository,
            IMaterialDomainRepository materialRepository,
            ICommentDomainRepository commentRepository)
        : IRequestHandler<CreateCommentCommand, CreateCommentOutputModel>
    {
        public async Task<CreateCommentOutputModel> Handle(
            CreateCommentCommand request,
            CancellationToken cancellationToken)
        {
            var creator = await creatorRepository.FindByUser(
                currentUser.UserId,
                cancellationToken);

            var material = await materialRepository.Find(
                request.MaterialId,
                cancellationToken);

            if (material == null)
            {
                return null;
            }

            var comment = new Comment()
            {
                Content = request.Content,
                CreatorId = creator.Id,
                MaterialId = request.MaterialId
            };

            creator.AddComment(comment);
            material.AddComment(comment);

            await commentRepository.Save(comment, cancellationToken);

            return new CreateCommentOutputModel(comment.Id);
        }
    }
}
