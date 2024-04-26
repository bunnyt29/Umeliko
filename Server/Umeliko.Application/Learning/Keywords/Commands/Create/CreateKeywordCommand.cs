namespace Umeliko.Application.Learning.Keywords.Commands.Create;

using Common;
using Domain.Learning.Models.Materials;
using Domain.Learning.Repositories;
using MediatR;

public class CreateKeywordCommand : EntityCommand<int>, IRequest<CreateKeywordOutputModel>
{
    public string Name { get; set; } = default!;

    public string BannerId { get; set; } = default!;

    public class CreateKeywordCommandHandler(
            IBannerDomainRepository bannerRepository,
            IKeywordDomainRepository keywordRepository)
        : IRequestHandler<CreateKeywordCommand, CreateKeywordOutputModel>
    {
        public async Task<CreateKeywordOutputModel> Handle(
            CreateKeywordCommand request,
            CancellationToken cancellationToken)
        {
            var banner = await bannerRepository.Find(
                request.BannerId,
                cancellationToken);

            if (banner == null)
            {
                return null;
            }

            var keyword = new Keyword(request.Name, request.BannerId);

            banner.AddKeyword(keyword);

            await keywordRepository.Save(keyword, cancellationToken);

            return new CreateKeywordOutputModel(keyword.Id);
        }
    }
}
