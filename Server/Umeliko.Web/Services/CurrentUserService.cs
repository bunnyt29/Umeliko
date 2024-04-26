namespace Umeliko.Web.Services;

using Application.Common.Contracts;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

public class CurrentUserService : ICurrentUser
{
    public CurrentUserService(IHttpContextAccessor httpContextAccessor)
    {
        var user = httpContextAccessor.HttpContext?.User;

        if (user == null)
        {
            throw new InvalidOperationException("This request does not have an authenticated user.");
        }

        this.UserId = user.FindFirstValue(ClaimTypes.NameIdentifier);
        this.UserName = user.FindFirstValue(ClaimTypes.Name);
    }

    public string UserId { get; }

    public string UserName { get; }
}
