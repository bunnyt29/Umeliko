namespace Umeliko.Web.Features;

using Application.Learning.Keywords.Commands.Create;
using Application.Learning.Keywords.Commands.Delete;
using Application.Learning.Keywords.Queries.ByBanner;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

public class KeywordsController : ApiController
{
    [HttpGet]
    [Route(nameof(ByBanner))]
    public async Task<ActionResult<KeywordsByBannerOutputModel>> ByBanner(
        KeywordsByBannerQuery query)
        => await this.Send(query);

    [HttpPost]
    [Authorize]
    public async Task<ActionResult<CreateKeywordOutputModel>> Create(
        CreateKeywordCommand command)
        => await this.Send(command);

    [HttpDelete]
    [Authorize]
    public async Task<ActionResult> Delete(
        DeleteKeywordCommand command)
        => await this.Send(command);
}
