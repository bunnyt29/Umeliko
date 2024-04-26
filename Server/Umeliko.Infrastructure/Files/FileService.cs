namespace Umeliko.Infrastructure.Files;

using Application.Common;
using Application.Files;
using Application.Files.Commands.UploadImage;
using Application.Files.Commands.UploadRaw;
using Application.Files.Commands.UploadVideo;
using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;

internal class FileService(IOptions<ApplicationSettings> applicationSettings) : IFile
{
    private const string NoFileProvidedErrorMessage = "No file was uploaded.";

    public async Task<Result<UploadImageOutputModel>> UploadImage(IFormFile image)
    {
        Cloudinary cloudinary = new Cloudinary(applicationSettings.Value.CloudinarySecret);

        if (image == null || image.Length == 0)
        {
            return NoFileProvidedErrorMessage;
        }

        using var stream = new MemoryStream();
        await image.CopyToAsync(stream);
        stream.Position = 0; // Reset the position of the stream to the beginning

        var uploadParams = new ImageUploadParams()
        {
            File = new FileDescription(image.FileName, stream),
            PublicId = image.FileName,
        };

        var uploadResult = await cloudinary.UploadAsync(uploadParams);

        var imageUrl = uploadResult.SecureUrl.ToString();

        return new UploadImageOutputModel(imageUrl);
    }

    public async Task<Result<UploadVideoOutputModel>> UploadVideo(IFormFile video)
    {
        Cloudinary cloudinary = new Cloudinary(applicationSettings.Value.CloudinarySecret);

        if (video == null || video.Length == 0)
        {
            return NoFileProvidedErrorMessage;
        }

        using var stream = new MemoryStream();
        await video.CopyToAsync(stream);
        stream.Position = 0;

        var uploadParams = new VideoUploadParams()
        {
            File = new FileDescription(video.FileName, stream),
            PublicId = video.FileName
        };

        var uploadResult = await cloudinary.UploadLargeAsync(uploadParams);

        var videoUrl = uploadResult.SecureUrl.ToString();

        return new UploadVideoOutputModel(videoUrl);
    }

    public async Task<Result<UploadRawOutputModel>> UploadRaw(IFormFile raw)
    {
        Cloudinary cloudinary = new Cloudinary(applicationSettings.Value.CloudinarySecret);

        if (raw == null || raw.Length == 0)
        {
            return NoFileProvidedErrorMessage;
        }

        using var stream = new MemoryStream();
        await raw.CopyToAsync(stream);
        stream.Position = 0;

        var uploadParams = new RawUploadParams()
        {
            File = new FileDescription(raw.FileName, stream),
            PublicId = raw.FileName,
        };

        var uploadResult = await cloudinary.UploadLargeAsync(uploadParams);

        var rawUrl = uploadResult.SecureUrl.ToString();

        return new UploadRawOutputModel(rawUrl);
    }
}
