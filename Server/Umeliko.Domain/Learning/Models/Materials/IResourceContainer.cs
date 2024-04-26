namespace Umeliko.Domain.Learning.Models.Materials;

public interface IResourceContainer
{
    IReadOnlyCollection<Resource> Resources { get; }

    void AddResource(Resource resource);
}
