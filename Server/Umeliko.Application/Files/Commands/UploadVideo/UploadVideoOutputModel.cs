namespace Umeliko.Application.Files.Commands.UploadVideo;

public class UploadVideoOutputModel(string videoUrl)
{
    public string VideoUrl { get; } = videoUrl;
}
