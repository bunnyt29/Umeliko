namespace Umeliko.Application.Identity.Commands.ChangeUsername;

public class ChangeUserNameInputModel(
    string userId,
    string userName)
{
    public string UserId { get; } = userId;

    public string UserName { get; } = userName;
}
