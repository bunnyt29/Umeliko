namespace Umeliko.Application.Identity.Commands.ChangeEmail;

public class ChangeEmailInputModel(
    string userId,
    string email)
{
    public string UserId { get; } = userId;

    public string Email { get; } = email;
}
