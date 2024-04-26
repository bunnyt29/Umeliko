namespace Umeliko.Domain.Learning.Models.Materials;

using Common;
using Common.Models;
using Events.Materials;
using Exceptions;

using static ModelConstants.Section;

public class Section : Entity<int>, IAggregateRoot
{
    private readonly HashSet<Item> items;

    public Section(string title, string courseId)
    {
        this.ValidateTitle(title);

        this.Title = title;
        this.CourseId = courseId;

        this.items = new HashSet<Item>();
    }

    public string Title { get; set; }

    public string CourseId { get; set; }

    public Section UpdateTitle(string title)
    {
        this.Title = title;

        return this;
    }

    public IReadOnlyCollection<Item> Items => this.items.ToList().AsReadOnly();

    public void AddItem(Item item)
    {
        this.items.Add(item);

        this.RaiseEvent(new ItemAddedEvent());
    }

    private void ValidateTitle(string title)
        => Guard.ForStringLength<InvalidSectionException>(
            title,
            MinTitleLength,
            MaxTitleLength,
            nameof(this.Title));
}
