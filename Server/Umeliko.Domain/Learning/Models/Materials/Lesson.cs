namespace Umeliko.Domain.Learning.Models.Materials;

using Common;
using Common.Models;
using Events.Materials;

public class Lesson : Entity<string>, IAggregateRoot, IResourceContainer
{
    private readonly HashSet<Resource> resources;

    internal Lesson(
        string? content,
        string? fileUrl,
        string? materialId,
        int sectionId)
    {
        this.Id = Guid.NewGuid().ToString();

        this.Content = content;
        this.FileUrl = fileUrl;
        this.MaterialId = materialId;
        this.SectionId = sectionId;

        this.resources = new HashSet<Resource>();
    }

    public string? Content { get; private set; }

    public string? FileUrl { get; private set; }

    public string? MaterialId { get; private set; }

    public int SectionId { get; private set; }

    public Lesson UpdateContent(string? content)
    {
        this.Content = content;

        return this;
    }

    public Lesson UpdateFileUrl(string? fileUrl)
    {
        this.FileUrl = fileUrl;

        return this;
    }

    public IReadOnlyCollection<Resource> Resources => this.resources.ToList().AsReadOnly();

    public void AddResource(Resource resource)
    {
        this.resources.Add(resource);

        this.RaiseEvent(new ResourceAddedEvent());
    }
}
