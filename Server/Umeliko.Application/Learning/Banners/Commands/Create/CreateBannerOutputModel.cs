namespace Umeliko.Application.Learning.Banners.Commands.Create;

public class CreateBannerOutputModel(string bannerId)
{
    public string BannerId { get; } = bannerId;
}
