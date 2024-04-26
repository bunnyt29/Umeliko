namespace Umeliko.Web.Features;

using Application.Learning.Materials.Commands.Approve;
using Application.Learning.Materials.Commands.ChangeVisibility;
using Application.Learning.Materials.Commands.Create;
using Application.Learning.Materials.Commands.Delete;
using Application.Learning.Materials.Commands.Disapprove;
using Application.Learning.Materials.Queries.ByCreator;
using Application.Learning.Materials.Queries.Details;
using Application.Learning.Materials.Queries.Mine;
using Application.Learning.Materials.Queries.Preview;
using Application.Learning.Materials.Queries.Search;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

public class MaterialsController : ApiController
{
    [HttpGet]
    [Route(nameof(Search))]
    public async Task<ActionResult<SearchMaterialsOutputModel>> Search(
        [FromQuery] SearchMaterialsQuery query)
        => await this.Send(query);

    [HttpGet]
    [Authorize]
    [Route(nameof(Mine))]
    public async Task<ActionResult<MineMaterialsOutputModel>> Mine(
        [FromQuery] MineMaterialsQuery query)
        => await this.Send(query);

    [HttpGet]
    [Route(nameof(All))]
    public async Task<ActionResult<MaterialsByCreatorOutputModel>> All(
        [FromQuery] MaterialsByCreatorQuery query)
        => await this.Send(query);

    [HttpGet]
    [Route(nameof(ByCreator) + PathSeparator + Id)]
    public async Task<ActionResult<MaterialsByCreatorOutputModel>> ByCreator(
        [FromRoute] MaterialsByCreatorQuery query)
        => await this.Send(query);

    [HttpGet]
    [Authorize(Roles = Administrator)]
    [Route(nameof(Pending))]
    public async Task<ActionResult<MaterialsByCreatorOutputModel>> Pending(
        [FromQuery] MaterialsByCreatorQuery query)
        => await this.Send(query);

    [HttpGet]
    [Route(Id)]
    public async Task<ActionResult<MaterialDetailsOutputModel>> Details(
        [FromRoute] MaterialDetailsQuery query)
        => await this.Send(query);

    [HttpGet]
    [Authorize]
    [Route(Id + PathSeparator + nameof(Preview))]
    public async Task<ActionResult<MaterialDetailsOutputModel>> Preview(
        [FromRoute] MaterialPreviewQuery query)
        => await this.Send(query);

    [HttpPost]
    [Authorize]
    public async Task<ActionResult<CreateMaterialOutputModel>> Create(
        CreateMaterialCommand command)
        => await this.Send(command);

    [HttpPut]
    [Authorize]
    [Route(Id + PathSeparator + nameof(ChangeVisibility))]
    public async Task<ActionResult> ChangeVisibility(
        [FromRoute] ChangeVisibilityCommand query)
        => await this.Send(query);

    [HttpPut]
    [Authorize(Roles = Administrator)]
    [Route(Id + PathSeparator + nameof(Approve))]
    public async Task<ActionResult> Approve(
        [FromRoute] ApproveCommand query)
        => await this.Send(query);

    [HttpPut]
    [Authorize(Roles = Administrator)]
    [Route(nameof(Disapprove))]
    public async Task<ActionResult> Disapprove(
        DisapproveCommand query)
        => await this.Send(query);

    [HttpDelete]
    [Authorize]
    [Route(Id)]
    public async Task<ActionResult> Delete(
        [FromRoute] DeleteMaterialCommand command)
        => await this.Send(command);
}
