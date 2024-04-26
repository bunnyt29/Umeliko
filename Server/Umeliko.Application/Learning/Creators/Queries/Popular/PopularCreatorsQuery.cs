namespace Umeliko.Application.Learning.Creators.Queries.Popular;

using Application.Common.Contracts;
using Common;
using Domain.Learning.Repositories;
using MediatR;

public class PopularCreatorsQuery : CreatorsQuery, IRequest<PopularCreatorsOutputModel>
{
    public class PopularCreatorsQueryHandler(
            ICreatorQueryRepository creatorRepository,
            ICreatorDomainRepository creatorDomainRepository,
            ICurrentUser currentUser)
        : CreatorsQueryHandler(creatorRepository), IRequestHandler<
            PopularCreatorsQuery,
            PopularCreatorsOutputModel>
    {
        public async Task<PopularCreatorsOutputModel> Handle(
            PopularCreatorsQuery request,
            CancellationToken cancellationToken)
        {
            var currentCreator = await creatorDomainRepository.FindByUser(
                currentUser.UserId,
                cancellationToken);

            var creatorListings = await GetCreatorListings<CreatorOutputModel>(
                currentCreator.Id,
                cancellationToken);

            foreach (var creator in creatorListings)
            {
                creator.UserName = await creatorRepository.GetUserName(creator.Id, cancellationToken);
            }

            return new PopularCreatorsOutputModel(creatorListings);
        }
    }
}
