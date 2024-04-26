namespace Umeliko.Application.Identity.Commands.ChangeEmail;

using Common;
using Common.Contracts;
using MediatR;

public class ChangeEmailCommand : IRequest<Result>
{
    public string Email { get; set; } = default!;

    public class ChangeEmailCommandHandler(
            ICurrentUser currentUser,
            IIdentity identity)
        : IRequestHandler<ChangeEmailCommand, Result>
    {
        public async Task<Result> Handle(
            ChangeEmailCommand request,
            CancellationToken cancellationToken)
            => await identity.ChangeEmail(new ChangeEmailInputModel(
                currentUser.UserId,
                request.Email));
    }
}
