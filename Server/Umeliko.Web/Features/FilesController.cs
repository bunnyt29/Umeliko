namespace Umeliko.Web.Features;

using Application.Files.Commands.UploadImage;
using Application.Files.Commands.UploadRaw;
using Application.Files.Commands.UploadVideo;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

public class FilesController : ApiController
{
    [HttpPost]
    [Authorize]
    [Route(nameof(UploadImage))]
    public async Task<ActionResult<UploadImageOutputModel>> UploadImage(
        UploadImageCommand command)
        => await this.Send(command);

    [HttpPost]
    [Authorize]
    [Route(nameof(UploadVideo))]
    public async Task<ActionResult<UploadVideoOutputModel>> UploadVideo(
        UploadVideoCommand command)
        => await this.Send(command);

    [HttpPost]
    [Authorize]
    [Route(nameof(UploadRaw))]
    public async Task<ActionResult<UploadRawOutputModel>> UploadRaw(
        UploadRawCommand command)
        => await this.Send(command);
}
