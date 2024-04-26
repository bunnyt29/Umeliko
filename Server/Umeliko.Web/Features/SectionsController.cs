namespace Umeliko.Web.Features;
using Application.Learning.Sections.Commands.Create;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

public class SectionsController : ApiController
{
    [HttpPost]
    [Authorize]
    public async Task<ActionResult<CreateSectionOutputModel>> Create(
        CreateSectionCommand command)
        => await this.Send(command);
}
