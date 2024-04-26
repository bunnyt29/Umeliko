namespace Umeliko.Application.Learning.Keywords.Commands.Delete;

using Common;
using Domain.Common.Models;
using MediatR;
using Umeliko.Domain.Learning.Repositories;

public class DeleteKeywordCommand : Entity<int>, IRequest<Result>
{
    public string BannerId { get; set; } = default!;

    public class DeleteKeywordCommandHandler(
            IKeywordDomainRepository keywordRepository,
            IBannerDomainRepository bannerRepository)
        : IRequestHandler<DeleteKeywordCommand, Result>
    {
        public async Task<Result> Handle(
            DeleteKeywordCommand request,
            CancellationToken cancellationToken)
        {
            var bannerHasKeyword = await bannerRepository.BannerHasKeyword(
                request.BannerId,
                request.Id,
                cancellationToken);

            if (!bannerHasKeyword)
            {
                return bannerHasKeyword;
            }

            return await keywordRepository.Delete(
                request.Id,
                cancellationToken);
        }
    }
}
