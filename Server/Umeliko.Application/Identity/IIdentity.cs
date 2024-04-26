namespace Umeliko.Application.Identity;

using Commands;
using Commands.ChangeEmail;
using Commands.ChangePassword;
using Commands.ChangeUsername;
using Commands.ConfirmEmail;
using Commands.CreateUser;
using Commands.LoginUser;
using Common;

public interface IIdentity
{
    Task<Result<IUser>> Register(CreateUserCommand userInput);

    Task<Result<LoginSuccessModel>> Login(UserInputModel userInput);

    Task<Result> ChangeUserName(ChangeUserNameInputModel changeUserNameInput);

    Task<Result> ChangeEmail(ChangeEmailInputModel changeEmailInput);

    Task<Result> ConfirmEmail(ConfirmEmailInputModel confirmEmailInput);

    Task<Result> ChangePassword(ChangePasswordInputModel changePasswordInput);
}
