namespace Umeliko.Application.Files.Commands.UploadRaw;

public class UploadRawOutputModel(string rawUrl)
{
    public string RawUrl { get; } = rawUrl;
}
