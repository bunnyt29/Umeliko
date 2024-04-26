namespace Umeliko.Application.Identity.Commands.LoginUser;

using Common;
using Domain.Learning.Repositories;
using MediatR;

public class LoginUserCommand : UserInputModel, IRequest<Result<LoginOutputModel>>
{
    public class LoginUserCommandHandler(
            IIdentity identity,
            ICreatorDomainRepository creatorRepository)
        : IRequestHandler<LoginUserCommand, Result<LoginOutputModel>>
    {
        public async Task<Result<LoginOutputModel>> Handle(
            LoginUserCommand request,
            CancellationToken cancellationToken)
        {
            var result = await identity.Login(request);

            if (!result.Succeeded)
            {
                return result.Errors;
            }

            var user = result.Data;

            var creatorId = user.IsAdmin ? user.UserId : await creatorRepository.GetCreatorId(user.UserId, cancellationToken);

            return new LoginOutputModel(user.Token, creatorId);
        }
    }
}
