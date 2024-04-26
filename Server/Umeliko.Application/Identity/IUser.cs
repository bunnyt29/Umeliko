namespace Umeliko.Application.Identity;

using Domain.Learning.Models.Creators;

public interface IUser
{
    void BecomeCreator(Creator creator);
}
