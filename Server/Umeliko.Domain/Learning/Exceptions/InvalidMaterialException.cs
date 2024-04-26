namespace Umeliko.Domain.Learning.Exceptions;

using Common;

public class InvalidMaterialException : BaseDomainException
{
    public InvalidMaterialException()
    {
    }

    public InvalidMaterialException(string error) => this.Error = error;
}
