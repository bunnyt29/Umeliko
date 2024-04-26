namespace Umeliko.Application.Identity.Commands.ChangePassword;

using Common;
using Common.Contracts;
using MediatR;

public class ChangePasswordCommand : IRequest<Result>
{
    public string CurrentPassword { get; set; } = default!;

    public string NewPassword { get; set; } = default!;

    public class ChangePasswordCommandHandler(
        ICurrentUser currentUser,
        IIdentity identity)
        : IRequestHandler<ChangePasswordCommand, Result>
    {
        public async Task<Result> Handle(
            ChangePasswordCommand request,
            CancellationToken cancellationToken)
            => await identity.ChangePassword(new ChangePasswordInputModel(
                currentUser.UserId,
                request.CurrentPassword,
                request.NewPassword));
    }
}
