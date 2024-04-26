namespace Umeliko.Web.Features;

using Application.Learning.Items.Commands.Create;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

public class ItemsController : ApiController
{
    [HttpPost]
    [Authorize]
    public async Task<ActionResult<CreateItemOutputModel>> Create(
        CreateItemCommand command)
        => await this.Send(command);
}
