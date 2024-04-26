namespace Umeliko.Application.Files;

using Commands.UploadImage;
using Commands.UploadRaw;
using Commands.UploadVideo;
using Common;
using Microsoft.AspNetCore.Http;

public interface IFile
{
    Task<Result<UploadImageOutputModel>> UploadImage(IFormFile image);

    Task<Result<UploadVideoOutputModel>> UploadVideo(IFormFile video);

    Task<Result<UploadRawOutputModel>> UploadRaw(IFormFile raw);
}
