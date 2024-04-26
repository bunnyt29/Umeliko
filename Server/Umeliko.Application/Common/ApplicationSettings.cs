namespace Umeliko.Application.Common;

public class ApplicationSettings
{
    public ApplicationSettings()
    {
        this.Secret = default!;
        this.CloudinarySecret = "cloudinary://782453593165514:dug1aDhRwYOAQK0HzzTXXe_jpyU@dxqy3jgj3";
    }

    public string Secret { get; private set; }

    public string CloudinarySecret { get; private set; }
}
