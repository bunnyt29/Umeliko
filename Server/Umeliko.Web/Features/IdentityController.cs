﻿namespace Umeliko.Web.Features;

using Application.Identity.Commands.ChangeEmail;
using Application.Identity.Commands.ChangePassword;
using Application.Identity.Commands.ChangeUsername;
using Application.Identity.Commands.ConfirmEmail;
using Application.Identity.Commands.CreateUser;
using Application.Identity.Commands.LoginUser;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

public class IdentityController : ApiController
{
    [HttpPost]
    [Route(nameof(Register))]
    public async Task<ActionResult> Register(
        CreateUserCommand command)
        => await this.Send(command);

    [HttpPost]
    [Route(nameof(Login))]
    public async Task<ActionResult<LoginOutputModel>> Login(
        LoginUserCommand command)
        => await this.Send(command);

    [HttpPut]
    [Authorize]
    [Route(nameof(ChangeUserName))]
    public async Task<ActionResult> ChangeUserName(
        ChangeUserNameCommand command)
        => await this.Send(command);

    [HttpPut]
    [Authorize]
    [Route(nameof(ChangeEmail))]
    public async Task<ActionResult> ChangeEmail(
        ChangeEmailCommand command)
        => await this.Send(command);

    [HttpPost]
    [Route(nameof(ConfirmEmail))]
    public async Task<ActionResult> ConfirmEmail(
        ConfirmEmailCommand command)
        => await this.Send(command);

    [HttpPut]
    [Authorize]
    [Route(nameof(ChangePassword))]
    public async Task<ActionResult> ChangePassword(
        ChangePasswordCommand command)
        => await this.Send(command);
}
