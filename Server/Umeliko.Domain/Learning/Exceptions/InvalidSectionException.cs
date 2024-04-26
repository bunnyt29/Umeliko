namespace Umeliko.Domain.Learning.Exceptions;

using Common;

public class InvalidSectionException : BaseDomainException
{
    public InvalidSectionException()
    {
    }

    public InvalidSectionException(string error) => this.Error = error;
}
