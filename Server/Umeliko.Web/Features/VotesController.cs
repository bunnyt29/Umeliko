namespace Umeliko.Web.Features;

using Application.Rating.Votes.Commands.Create;
using Application.Rating.Votes.Commands.Delete;
using Application.Rating.Votes.Queries.Common;
using Application.Rating.Votes.Queries.Details;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

public class VotesController : ApiController
{
    [HttpPost]
    [Authorize]
    public async Task<ActionResult<CreateVoteOutputModel>> Create(
        CreateVoteCommand command)
        => await this.Send(command);

    [HttpGet]
    [Route(MaterialId)]
    public async Task<ActionResult<VoteOutputModel>> Details(
        [FromRoute] VoteDetailsQuery query)
        => await this.Send(query);

    [HttpDelete]
    [Authorize]
    public async Task<ActionResult> Delete(
        DeleteVoteCommand command)
        => await this.Send(command);
}
