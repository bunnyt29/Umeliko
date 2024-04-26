namespace Umeliko.Application.Identity.Commands.ConfirmEmail;

using Common;
using Common.Contracts;
using MediatR;

public class ConfirmEmailCommand : IRequest<Result>
{
    public string UserId { get; set; } = default!;

    public string Token { get; set; } = default!;

    public class ConfirmEmailCommandHandler(
            ICurrentUser currentUser,
            IIdentity identity)
        : IRequestHandler<ConfirmEmailCommand, Result>
    {
        public async Task<Result> Handle(
            ConfirmEmailCommand request,
            CancellationToken cancellationToken)
            => await identity.ConfirmEmail(new ConfirmEmailInputModel(
                request.UserId,
                request.Token));
    }
}
