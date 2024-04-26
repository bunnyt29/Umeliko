namespace Umeliko.Application.Identity.Commands.LoginUser;

public class LoginOutputModel(string token, string creatorId)
{
    public string CreatorId { get; } = creatorId;

    public string Token { get; } = token;
}
