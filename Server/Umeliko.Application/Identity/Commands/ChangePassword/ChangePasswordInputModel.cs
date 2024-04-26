namespace Umeliko.Application.Identity.Commands.ChangePassword;

public class ChangePasswordInputModel(
    string userId,
    string currentPassword,
    string newPassword)
{
    public string UserId { get; } = userId;

    public string CurrentPassword { get; } = currentPassword;

    public string NewPassword { get; } = newPassword;
}
