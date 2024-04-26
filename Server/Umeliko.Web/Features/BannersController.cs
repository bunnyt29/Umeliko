namespace Umeliko.Web.Features;

using Application.Learning.Banners.Commands.Create;
using Application.Learning.Banners.Commands.Delete;
using Application.Learning.Banners.Commands.Edit;
using Application.Learning.Banners.Queries.Details;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

public class BannersController : ApiController
{
    [HttpGet]
    [Route(MaterialId)]
    public async Task<ActionResult<BannerDetailsOutputModel>> Details(
        [FromRoute] BannerDetailsQuery query)
        => await this.Send(query);

    [HttpPost]
    [Authorize]
    public async Task<ActionResult<CreateBannerOutputModel>> Create(
        CreateBannerCommand command)
        => await this.Send(command);

    [HttpPut]
    [Authorize]
    public async Task<ActionResult> Edit(
        EditBannerCommand command)
        => await this.Send(command);

    [HttpDelete]
    [Authorize]
    public async Task<ActionResult> Delete(
        DeleteBannerCommand command)
        => await this.Send(command);
}
