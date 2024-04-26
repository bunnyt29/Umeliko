namespace Umeliko.Infrastructure.Identity;

using Application.Common;
using Application.Identity;
using Application.Identity.Commands;
using Application.Identity.Commands.ChangeEmail;
using Application.Identity.Commands.ChangePassword;
using Application.Identity.Commands.ChangeUsername;
using Application.Identity.Commands.ConfirmEmail;
using Application.Identity.Commands.CreateUser;
using Application.Identity.Commands.LoginUser;
using Microsoft.AspNetCore.Identity;
using SendGrid;
using SendGrid.Helpers.Mail;
using System.Web;

internal class IdentityService(
        UserManager<User> userManager,
        IJwtTokenGenerator jwtTokenGenerator)
    : IIdentity
{
    private const string InvalidErrorMessage = "Invalid credentials.";
    private const string UnconfirmedEmailErrorMessage = "Email is not confirmed.";

    public async Task<Result<IUser>> Register(CreateUserCommand userInput)
    {
        var user = new User(
            userInput.Email,
            userInput.UserName);

        user.EmailConfirmed = false;

        var identityResult = await userManager.CreateAsync(user, userInput.Password);

        var errors = identityResult.Errors.Select(e => e.Description);

        if (identityResult.Succeeded)
        {
            await this.SendConfirmationEmail(user);
        }

        return identityResult.Succeeded
            ? Result<IUser>.SuccessWith(user)
            : Result<IUser>.Failure(errors);
    }

    public async Task<Result<LoginSuccessModel>> Login(UserInputModel userInput)
    {
        var user = await userManager.FindByEmailAsync(userInput.Email)
                   ?? await userManager.FindByNameAsync(userInput.Email);

        if (user == null)
        {
            return InvalidErrorMessage;
        }

        if (!user.EmailConfirmed)
        {
            return UnconfirmedEmailErrorMessage;
        }

        var passwordValid = await userManager.CheckPasswordAsync(user, userInput.Password);
        if (!passwordValid)
        {
            return InvalidErrorMessage;
        }

        var roles = await userManager.GetRolesAsync(user);

        bool isAdmin = roles.Contains("Administrator");

        var token = jwtTokenGenerator.GenerateToken(user, roles);

        return new LoginSuccessModel(user.Id, token, isAdmin);
    }

    public async Task<Result> ChangeUserName(ChangeUserNameInputModel changeUserNameInput)
    {
        var user = await userManager.FindByIdAsync(changeUserNameInput.UserId);

        if (user == null)
        {
            return InvalidErrorMessage;
        }

        user.UserName = changeUserNameInput.UserName;
        user.NormalizedUserName = changeUserNameInput.UserName.ToUpper();

        var identityResult = await userManager.UpdateAsync(user);

        var errors = identityResult.Errors.Select(e => e.Description);

        return identityResult.Succeeded
            ? Result.Success
            : Result.Failure(errors);
    }

    public async Task<Result> ChangeEmail(ChangeEmailInputModel changeEmailInput)
    {
        var user = await userManager.FindByIdAsync(changeEmailInput.UserId);

        if (user == null)
        {
            return InvalidErrorMessage;
        }

        user.Email = changeEmailInput.Email;
        user.NormalizedEmail = changeEmailInput.Email.ToUpper();
        user.EmailConfirmed = false;

        var identityResult = await userManager.UpdateAsync(user);

        if (!identityResult.Succeeded)
        {
            return Result.Failure(identityResult.Errors.Select(e => e.Description));
        }

        await SendConfirmationEmail(user);

        return Result.Success;
    }

    private async Task SendConfirmationEmail(User user)
    {
        var token = await userManager.GenerateEmailConfirmationTokenAsync(user);
        //var confirmationLink = $"https://umeliko.web.app/auth/confirm-email?userId={user.Id}&token={HttpUtility.UrlEncode(token)}";
        var confirmationLink = $"http://localhost:4200/auth/confirm-email?userId={user.Id}&token={HttpUtility.UrlEncode(token)}";

        var client = new SendGridClient(Environment.GetEnvironmentVariable("SENDGRID_API_KEY"));
        var from = new EmailAddress("umeliko.team@gmail.com", "Екипът на Умелико");
        var to = new EmailAddress(user.Email, user.UserName);
        var subject = "Потвърждение на имейл адрес";
        var htmlContent = $@"
        <html>
        <body style='font-family: Oswald, sans-serif;'>
          <p>Хей, {user.UserName}!</p>
          <p>Нека направим този имейл адрес официален - само трябва да потвърдиш, че си ти.</p>
          <p>
            Не се колебай, последвай връзката: <br/> <a href='{confirmationLink}'>потвърди имейл</a>
          </p>
          <p>Благодарим предварително!</p>
          <p>Поздрави, <br/> Екипът на Умелико</p>
        </body>
        </html>";

        var message = MailHelper.CreateSingleEmail(from, to, subject, null, htmlContent);

        await client.SendEmailAsync(message);
    }

    public async Task<Result> ConfirmEmail(ConfirmEmailInputModel confirmEmailInput)
    {
        var user = await userManager.FindByIdAsync(confirmEmailInput.UserId);

        if (user == null)
        {
            return InvalidErrorMessage;
        }

        var identityResult = await userManager.ConfirmEmailAsync(user, confirmEmailInput.Token);

        return identityResult.Succeeded
            ? Result.Success
            : Result.Failure(identityResult.Errors.Select(e => e.Description));
    }

    public async Task<Result> ChangePassword(ChangePasswordInputModel changePasswordInput)
    {
        var user = await userManager.FindByIdAsync(changePasswordInput.UserId);

        if (user == null)
        {
            return InvalidErrorMessage;
        }

        var identityResult = await userManager.ChangePasswordAsync(
            user,
            changePasswordInput.CurrentPassword,
            changePasswordInput.NewPassword);

        var errors = identityResult.Errors.Select(e => e.Description);

        return identityResult.Succeeded
            ? Result.Success
            : Result.Failure(errors);
    }
}
