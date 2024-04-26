namespace Umeliko.Application.Identity.Commands.ConfirmEmail;

public class ConfirmEmailInputModel(
    string userId,
    string token)
{
    public string UserId { get; } = userId;

    public string Token { get; } = token;
}
