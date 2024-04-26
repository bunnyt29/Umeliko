namespace Umeliko.Domain.Learning.Exceptions;

using Common;

public class InvalidCreatorException : BaseDomainException
{
    public InvalidCreatorException()
    {
    }

    public InvalidCreatorException(string error) => this.Error = error;
}