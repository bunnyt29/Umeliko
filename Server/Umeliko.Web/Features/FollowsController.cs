namespace Umeliko.Web.Features;

using Application.Learning.Follows.Commands.Create;
using Application.Learning.Follows.Commands.Delete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

public class FollowsController : ApiController
{
    [HttpPost]
    [Authorize]
    [Route(CreatorId)]
    public async Task<ActionResult> Create(
        [FromRoute] CreateFollowCommand command)
        => await this.Send(command);

    [HttpDelete]
    [Authorize]
    [Route(CreatorId)]
    public async Task<ActionResult> Delete(
        [FromRoute] DeleteFollowCommand command)
        => await this.Send(command);
}
