namespace Umeliko.Web.Features;

using Application.Common;
using Application.Learning.Creators.Commands.Edit;
using Application.Learning.Creators.Queries.Details;
using Application.Learning.Creators.Queries.Popular;
using Microsoft.AspNetCore.Mvc;

public class CreatorsController : ApiController
{
    [HttpGet]
    [Route(Id)]
    public async Task<ActionResult<CreatorDetailsOutputModel>> Details(
        [FromRoute] CreatorDetailsQuery query)
        => await this.Send(query);

    [HttpGet]
    public async Task<ActionResult<CreatorDetailsOutputModel>> Myself(
        [FromQuery] CreatorDetailsQuery query)
        => await this.Send(query);

    [HttpGet]
    [Route(nameof(Popular))]
    public async Task<ActionResult<PopularCreatorsOutputModel>> Popular(
        [FromQuery] PopularCreatorsQuery query)
        => await this.Send(query);

    [HttpPut]
    [Route(Id)]
    public async Task<ActionResult> Edit(
        string id, EditCreatorCommand command)
        => await this.Send(command.SetId(id));
}
