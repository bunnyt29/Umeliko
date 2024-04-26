namespace Umeliko.Web.Features;

using Application.Rating.Comments.Commands.Create;
using Application.Rating.Comments.Commands.Delete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

public class CommentsController : ApiController
{
    [HttpPost]
    [Authorize]
    public async Task<ActionResult<CreateCommentOutputModel>> Create(
        CreateCommentCommand command)
        => await this.Send(command);

    [HttpDelete]
    [Authorize]
    [Route(MaterialId + PathSeparator + Id)]
    public async Task<ActionResult> Delete(
        [FromRoute] DeleteCommentCommand command)
        => await this.Send(command);
}
