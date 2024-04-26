namespace Umeliko.Infrastructure.Identity;

using Application.Identity;
using Domain.Learning.Exceptions;
using Domain.Learning.Models.Creators;
using Microsoft.AspNetCore.Identity;

public class User : IdentityUser, IUser
{
    internal User()
    {

    }

    internal User(
        string email,
        string userName)
        : base(userName)
    {
        this.Email = email;
    }

    public Creator? Creator { get; private set; }

    public void BecomeCreator(Creator creator)
    {
        if (this.Creator != null)
        {
            throw new InvalidCreatorException($"User '{this.UserName}' is already a creator.");
        }

        this.Creator = creator;
    }
}
