namespace Umeliko.Application.Learning.Materials.Commands.Common;

using Application.Common;

public abstract class MaterialCommand<TCommand> : EntityCommand<string>
    where TCommand : EntityCommand<string>
{
    public int ContentType { get; set; }
}
