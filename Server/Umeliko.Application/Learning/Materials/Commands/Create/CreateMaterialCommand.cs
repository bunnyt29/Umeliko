namespace Umeliko.Application.Learning.Materials.Commands.Create;

using Application.Common.Contracts;
using Common;
using Domain.Common.Models;
using Domain.Learning.Factories.Materials;
using Domain.Learning.Models.Materials;
using Domain.Learning.Repositories;
using MediatR;

public class CreateMaterialCommand : MaterialCommand<CreateMaterialCommand>, IRequest<CreateMaterialOutputModel>
{
    public class CreateMaterialCommandHandler(
            ICurrentUser currentUser,
            ICreatorDomainRepository creatorRepository,
            IMaterialDomainRepository materialRepository,
            IMaterialFactory materialFactory)
        : IRequestHandler<CreateMaterialCommand, CreateMaterialOutputModel>
    {
        public async Task<CreateMaterialOutputModel> Handle(
            CreateMaterialCommand request,
            CancellationToken cancellationToken)
        {
            var creator = await creatorRepository.FindByUser(
                currentUser.UserId,
                cancellationToken);

            var material = materialFactory
                .WithContentType(Enumeration.FromValue<ContentType>(request.ContentType))
                .WithStateType(Enumeration.FromValue<StateType>(1))
                .Build();

            creator.AddMaterial(material);

            await materialRepository.Save(material, cancellationToken);

            return new CreateMaterialOutputModel(material.Id);
        }
    }
}
