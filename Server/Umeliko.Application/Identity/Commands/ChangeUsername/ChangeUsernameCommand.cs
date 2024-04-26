namespace Umeliko.Application.Identity.Commands.ChangeUsername;

using Common;
using Common.Contracts;
using MediatR;

public class ChangeUserNameCommand : IRequest<Result>
{
    public string UserName { get; set; } = default!;

    public class ChangeUsernameCommandHandler(
        ICurrentUser currentUser,
        IIdentity identity)
        : IRequestHandler<ChangeUserNameCommand, Result>
    {
        public async Task<Result> Handle(
            ChangeUserNameCommand request,
            CancellationToken cancellationToken)
            => await identity.ChangeUserName(new ChangeUserNameInputModel(
                currentUser.UserId,
                request.UserName));
    }
}
