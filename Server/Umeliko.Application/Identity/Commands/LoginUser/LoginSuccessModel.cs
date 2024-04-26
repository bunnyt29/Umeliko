namespace Umeliko.Application.Identity.Commands.LoginUser;

public class LoginSuccessModel(string userId, string token, bool isAdmin)
{
    public string UserId { get; } = userId;

    public string Token { get; } = token;

    public bool IsAdmin { get; } = isAdmin;
}
