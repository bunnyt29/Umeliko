namespace Umeliko.Domain.Learning.Models.Materials;

using Common;
using Common.Models;
using Events.Materials;

public class Course : Entity<string>, IAggregateRoot, IResourceContainer
{
    private readonly HashSet<Section> sections;
    private readonly HashSet<Resource> resources;

    internal Course(string? content, string materialId)
    {
        this.Id = Guid.NewGuid().ToString();

        this.Content = content;
        this.MaterialId = materialId;

        this.sections = new HashSet<Section>();
        this.resources = new HashSet<Resource>();
    }

    public string? Content { get; private set; }

    public string MaterialId { get; private set; }

    public Course UpdateContent(string? content)
    {
        this.Content = content;

        return this;
    }

    public IReadOnlyCollection<Section> Sections => this.sections.ToList().AsReadOnly();

    public void AddSection(Section section)
    {
        this.sections.Add(section);

        this.RaiseEvent(new SectionAddedEvent());
    }

    public IReadOnlyCollection<Resource> Resources => this.resources.ToList().AsReadOnly();

    public void AddResource(Resource resource)
    {
        this.resources.Add(resource);

        this.RaiseEvent(new ResourceAddedEvent());
    }
}
