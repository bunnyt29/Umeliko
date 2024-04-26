namespace Umeliko.Application.Identity.Commands.CreateUser;

using Common;
using Domain.Learning.Factories.Creators;
using Domain.Learning.Repositories;
using MediatR;

public class CreateUserCommand : UserInputModel, IRequest<Result>
{
    public string UserName { get; set; } = default!;

    public string FirstName { get; set; } = default!;

    public string LastName { get; set; } = default!;

    public class CreateUserCommandHandler(
            IIdentity identity,
            ICreatorFactory creatorFactory,
            ICreatorDomainRepository creatorRepository)
        : IRequestHandler<CreateUserCommand, Result>
    {
        public async Task<Result> Handle(
            CreateUserCommand request,
            CancellationToken cancellationToken)
        {
            var result = await identity.Register(request);

            if (!result.Succeeded)
            {
                return result;
            }

            var user = result.Data;

            var creator = creatorFactory
                .WithFirstName(request.FirstName)
                .WithLastName(request.LastName)
                .Build();

            user.BecomeCreator(creator);

            await creatorRepository.Save(creator, cancellationToken);

            return result;
        }
    }
}
