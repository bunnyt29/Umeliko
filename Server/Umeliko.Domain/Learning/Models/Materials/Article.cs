namespace Umeliko.Domain.Learning.Models.Materials;

using Common;
using Common.Models;
using Umeliko.Domain.Learning.Events.Materials;

public class Article : Entity<string>, IAggregateRoot, IResourceContainer
{
    private readonly HashSet<Resource> resources;

    internal Article(string content, string materialId)
    {
        this.Id = Guid.NewGuid().ToString();

        this.Content = content;
        this.MaterialId = materialId;

        this.resources = new HashSet<Resource>();
    }

    public string Content { get; private set; }

    public string MaterialId { get; private set; }

    //public int SectionId { get; set; } = default!;

    public Article UpdateContent(string text)
    {
        this.Content = text;

        return this;
    }

    public IReadOnlyCollection<Resource> Resources => this.resources.ToList().AsReadOnly();

    public void AddResource(Resource resource)
    {
        this.resources.Add(resource);

        this.RaiseEvent(new ResourceAddedEvent());
    }
}
