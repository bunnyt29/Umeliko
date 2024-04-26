namespace Umeliko.Domain.Learning.Exceptions;

using Common;

public class InvalidBannerException : BaseDomainException
{
    public InvalidBannerException()
    {
    }

    public InvalidBannerException(string error) => this.Error = error;
}
