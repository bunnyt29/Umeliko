namespace Umeliko.Application.Learning.Creators.Queries.Common;

public abstract class CreatorsQuery
{
    public abstract class CreatorsQueryHandler(ICreatorQueryRepository creatorRepository)
    {
        protected async Task<IEnumerable<TOutputModel>> GetCreatorListings<TOutputModel>(
            string currentCreatorId,
            CancellationToken cancellationToken = default)
        {
            return await creatorRepository.GetCreatorListings<TOutputModel>(currentCreatorId, cancellationToken);
        }
    }
}
